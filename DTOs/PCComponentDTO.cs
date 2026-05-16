namespace WebLesson1.DTOs
{
    public class PCComponentDTO
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Amount { get; set; }

    }
}
