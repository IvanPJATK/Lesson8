using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLesson1.Models
{
    public class Component
    {
        [Key]
        [Column(TypeName = "char(10)")]
        public string Code { get; set; } = null!;
        [Required]
        [MaxLength(300)]
        public string Name { get; set; } = null!;
        [MaxLength]
        public string? Description { get; set; }
        public int ComponentManufacturerId { get; set; }
        [ForeignKey(nameof(ComponentManufacturerId))]
        public ComponentManufacturer componentManufecturer { get; set; } = null!;
        public int ComponentTypeId { get; set; }
        [ForeignKey(nameof(ComponentTypeId))]
        public ComponentType componentType { get; set; } = null!;
        public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
    }
}
