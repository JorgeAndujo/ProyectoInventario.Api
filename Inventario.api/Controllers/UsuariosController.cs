using Azure.Messaging;
using Inventario.api.Helpers;
using Inventario.api.Models.Administracion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventario.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext context;

        public UsuariosController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Usuarios.ToList());

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var usuario = context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioBd = context.Usuarios.Where(x => x.Email.Equals(usuario.Email) || x.NombreUsuario.Equals(usuario.NombreUsuario)).FirstOrDefault();
                if (usuarioBd != null && usuarioBd.Id != usuario.Id)
                {
                    if(usuarioBd.NombreUsuario == usuario.NombreUsuario)
                    {
                        return BadRequest("USERNAME_ALREADY_EXISTS");
                    }
                    else
                    {
                        return BadRequest("EMAIL_ALREADY_EXISTS");
                    }
                }
                else
                {
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();
                    return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario usuario)
        {          
            try
            {
                if(usuario.Id == id)
                {
                    var usuarioBd = context.Usuarios.Where(x => x.Email.Equals(usuario.Email) || x.NombreUsuario.Equals(usuario.NombreUsuario)).FirstOrDefault();
                    if (usuarioBd != null && usuarioBd.Id != usuario.Id)
                    {
                        if (usuarioBd.NombreUsuario == usuario.NombreUsuario)
                        {
                            return BadRequest("USERNAME_ALREADY_EXISTS");
                        }
                        else
                        {
                            return BadRequest("EMAIL_ALREADY_EXISTS");
                        }
                    }
                    else
                    {
                        context.Entry(usuario).State = EntityState.Modified;
                        context.SaveChanges();
                        return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
                    }
                }
                else
                {
                    return BadRequest();
                }
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var usuario = context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                if(usuario != null)
                {
                    context.Usuarios.Remove(usuario);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("validateLogin/{nombreUsuario}")]
        public ActionResult Get(string nombreUsuario)
        {
            try
            {
                var usuario = context.Usuarios.Where(x => x.NombreUsuario.ToUpper() == nombreUsuario.ToUpper() || x.Email.ToUpper() == nombreUsuario.ToUpper()).FirstOrDefault();
                if(usuario != null)
                {
                    return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario); ;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("recoverPassword/{email}")]
        public async void RecoverPassword(string email)
        {
            try
            {
                Email oEmail = new Email();
                var usuario = context.Usuarios.Where(x => x.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
                if (usuario != null)
                {
                    await oEmail.SendEmail(usuario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
