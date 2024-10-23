namespace GundamAPI.Models
{
    public class Gundam
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Pilot { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
