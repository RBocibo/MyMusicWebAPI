using MyMusic.Core.Models;

namespace MyMusic.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllArtistAsync();
        Task<Artist> GetArtistByIdAsync(int id);
        Task<Artist> CreateArtist(Artist artist);
        Task DeleteArtist(int id);
        Task<Artist> UpdateArtistAsync(int id, Artist artist);
    }
}
