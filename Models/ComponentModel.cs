using Microsoft.AspNetCore.Components.Endpoints;

namespace WebLesson1.Models
{
    public class Component
    {
        string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int ComponentManufacturerId { get; set; }
        public ComponentManufacturer componentManufecturer { get; set; } = null!;
        public int ComponentTypeId { get; set; }
        public ComponentType componentType { get; set; } = null!;

    }
}
