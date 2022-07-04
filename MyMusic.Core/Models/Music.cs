namespace MyMusic.Core.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
