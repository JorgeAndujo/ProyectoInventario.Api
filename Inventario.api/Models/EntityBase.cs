using System.ComponentModel.DataAnnotations;

namespace Inventario.api.Models
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Activo { get; set; }
    }
}
