using MyMusic.Core.Interfaces;
using MyMusic.Core.Models;

namespace MyMusic.Services
{
    public class MusicService : IMusicService
    {
        private readonly IMusicRepository _musicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MusicService(IMusicRepository musicRepository, IUnitOfWork unitOfWork)
        {
            _musicRepository = musicRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Music> CreateMusicAsync(Music music)
        {
            var addMusic = new Music()
            {
                Id = music.Id,
                Name = music.Name,
                ArtistId = music.ArtistId,
            };

            var adding = await _musicRepository.AddAsync(addMusic);
            await _unitOfWork.CommitAsyc();
            return adding;
        }

        public async Task DeleteMusicAsync(int id)
        {
            var deleteMusic = await _musicRepository.GetByExpression(x => x.Id == id);

            if (deleteMusic == null)
            {
                return;
            }

             _musicRepository.DeleteAsync(x => x.Id == id);
            await _unitOfWork.CommitAsyc();

        }

        public async Task<IEnumerable<Music>> GetAllMusicAsync()
        {
            return await _musicRepository.GetAllAsync();
        }

        public async Task<Music> GetMusicByIdAsyc(int id)
        {
            var music = await _musicRepository.GetByExpression(x => x.Id == id);

            if (music == null)
            {
                return null;
            }

            return music;
        }

        public async Task<Music> UpdateMusicAsync(int id, Music music)
        {
            var updateMusic = await _musicRepository.GetByExpression(x => x.Id == id);

            if (updateMusic == null)
            {
                updateMusic = new Music()
                {
                    Id = id,
                    Name = music.Name,
                    ArtistId = music.ArtistId,
                };
            }
            else
            {
                updateMusic.Id = id;
                updateMusic.Name = music.Name != null ? music.Name : updateMusic.Name;
                updateMusic.ArtistId = updateMusic.ArtistId != null ? updateMusic.ArtistId : music.ArtistId;
            }
            await _musicRepository.UpdateAsync(updateMusic);
            await _unitOfWork.CommitAsyc();

            return updateMusic;
        }
    }
}
