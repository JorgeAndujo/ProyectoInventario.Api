using System.Net.Mail;
using System.Net;
using Inventario.api.Models.Administracion;

namespace Inventario.api.Helpers
{
    public class Email
    {
        interface IEmailInterface
        {
            Task SendEmail(Usuario usuarioSolicitud);
        }

        private readonly IConfiguration configuration;

        public Email(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Email()
        {
        }

        public async Task SendEmail(Usuario usuarioSolicitud)
        {
            var originEmail = "practicadevsjlae@gmail.com";
            var passwordOriginEmail = "yqbszvjplxrjgexq";
            //Netlify FrontEnd
            //var dirWeb = "https://clever-melba-9799cb.netlify.app/RecoverPassword/";
            //Local
            var dirWeb = "http://localhost:3000/recoverPassword/";

            MailMessage oMailMessage = new MailMessage(originEmail, usuarioSolicitud.Email, "Recuperación de contraseña InventarioSM", $"Para restablecer su contraseña entre al siguiente enlace: {dirWeb + usuarioSolicitud.Id}");

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmptClient = new SmtpClient("smtp.gmail.com");
            oSmptClient.EnableSsl = true;
            oSmptClient.UseDefaultCredentials = false;
            oSmptClient.Port = 587;
            oSmptClient.Credentials = new NetworkCredential(originEmail, passwordOriginEmail);

            oSmptClient.Send(oMailMessage);

            oSmptClient.Dispose();
        }
    }
}
