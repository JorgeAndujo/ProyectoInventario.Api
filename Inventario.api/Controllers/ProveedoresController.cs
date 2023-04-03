using Inventario.api.Migrations;
using Inventario.api.Models.Administracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProveedoresController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Proveedores.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetProveedor")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var proveedor = context.Proveedores.Where(x => x.Id == id).FirstOrDefault();
                return Ok(proveedor);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProveedoresController>
        [HttpPost]
        public ActionResult Post([FromBody] Proveedor proveedor)
        {
            try
            {
                var provBd = context.Proveedores.Where(x => x.Rfc.Equals(proveedor.Rfc) || x.RazonSocial.Equals(proveedor.RazonSocial)).FirstOrDefault();
                if (provBd != null && provBd.Id != proveedor.Id)
                {
                    if (provBd.Rfc == proveedor.Rfc)
                    {
                        return BadRequest("RFC_ALREADY_EXISTS");
                    }
                    else
                    {
                        return BadRequest("RAZONSOCIAL_ALREADY_EXISTS");
                    }
                }
                else
                {
                    context.Proveedores.Add(proveedor);
                    context.SaveChanges();
                    return CreatedAtRoute("GetProveedor", new { id = proveedor.Id }, proveedor);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProveedoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Proveedor proveedor)
        {
            try
            {
                if (proveedor.Id == id)
                {
                    var provBd = context.Proveedores.Where(x => x.Rfc.Equals(proveedor.Rfc) || x.RazonSocial.Equals(proveedor.RazonSocial)).FirstOrDefault();
                    if (provBd != null && provBd.Id != proveedor.Id)
                    {
                        if (provBd.Rfc == proveedor.Rfc)
                        {
                            return BadRequest("RFC_ALREADY_EXISTS");
                        }
                        else
                        {
                            return BadRequest("RAZONSOCIAL_ALREADY_EXISTS");
                        }
                    }
                    else
                    {
                        context.Entry(proveedor).State = EntityState.Modified;
                        context.SaveChanges();
                        return CreatedAtRoute("GetProveedor", new { id = proveedor.Id }, proveedor);
                    }
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

        // DELETE api/<ProveedorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var proveedor = context.Proveedores.Where(x => x.Id == id).FirstOrDefault();
                if (proveedor != null)
                {
                    context.Proveedores.Remove(proveedor);
                    context.SaveChanges();
                    return Ok(id);
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
    }
}
