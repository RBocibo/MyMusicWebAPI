using MyMusic.Core.Models;

namespace MyMusic.Services
{
    public interface IMusicService
    {
        Task<Music> GetMusicByIdAsyc(int id);
        Task<IEnumerable<Music>> GetAllMusicAsync();
        Task<Music> CreateMusicAsync(Music music);
        Task DeleteMusicAsync(int id);
        Task<Music> UpdateMusicAsync(int id, Music music);
    }
}
