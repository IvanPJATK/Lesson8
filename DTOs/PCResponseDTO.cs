namespace WebLesson1.DTOs
{
    public class PCResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Stock {  get; set; }
        public List<string> ComponentNames { get; set; } = new List<string>();
    }
}
