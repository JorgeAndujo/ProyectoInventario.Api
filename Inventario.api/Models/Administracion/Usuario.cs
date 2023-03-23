using Inventario.api.Enums;

namespace Inventario.api.Models.Administracion
{
    public class Usuario : EntityBase
    {
        public string? NombreUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Contrasenia { get; set; }
        public string? UrlImagen { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? Rol { get; set; }
    }
}
