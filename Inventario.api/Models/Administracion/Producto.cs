namespace Inventario.api.Models.Administracion
{
    public class Producto : EntityBase
    {
        public string? Clave { get; set; }
        public string? Nombre { get; set; }
        public string? Bimbo { get; set; }
        public string? Descripcion { get; set; }
        public string? UrlImagen { get; set; }
        public Proveedor? Proveedor { get; set; }
        public Guid ProveedorId { get; set; }
    }
}
