using System.ComponentModel.DataAnnotations;

namespace WebLesson1.Models
{
    public class PC
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public double Weight { get; set; }
        public int Warranty { get; set; }
        public int Stock { get; set; }
        public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
    }
}
