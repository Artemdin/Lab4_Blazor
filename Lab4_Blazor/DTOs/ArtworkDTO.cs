namespace Lab4_Blazor.DTOs
{
    public class ArtworkDTO
    {
        public string Title { get; set; } = string.Empty;
        public int CreationYear { get; set; } = DateTime.Now.Year;
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
    }
}