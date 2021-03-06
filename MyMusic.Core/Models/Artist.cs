namespace MyMusic.Core.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Music>? Musics { get; set; }
    }
}
