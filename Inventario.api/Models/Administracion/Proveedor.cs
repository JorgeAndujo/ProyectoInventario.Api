namespace Inventario.api.Models.Administracion
{
    public class Proveedor : EntityBase
    {
        public string? RazonSocial { get; set; }
        public string? Rfc { get; set; }
        public string? Correo { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? NombreComercial { get; set; }
    }
}
