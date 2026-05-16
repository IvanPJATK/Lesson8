using Microsoft.AspNetCore.Components.Endpoints;
using System.ComponentModel.DataAnnotations;

namespace WebLesson1.Models
{
    public class ComponentManufacturer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Abbreviation { get; set; } = null!;
        [Required]
        [MaxLength(300)]
        public string FullName { get; set; } = null!;
        public DateTime foundationDate {  get; set; }
        public ICollection<Component> Components { get; set; } = new List<Component>();
    }
}
