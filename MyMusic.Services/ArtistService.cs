using MyMusic.Core.Interfaces;
using MyMusic.Core.Models;

namespace MyMusic.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IArtistRepository artistRepository, IUnitOfWork unitOfWork)
        {
            _artistRepository = artistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Artist> CreateArtist(Artist artist)
        {
            var addArtist = new Artist()
            {
                Id = artist.Id,
                Name = artist.Name,
            };

             var adding = await _artistRepository.AddAsync(addArtist);
             await _unitOfWork.CommitAsyc();

            return adding;
        }

        public async Task DeleteArtist(int id)
        {
            var deletedArtist = await _artistRepository.GetByExpression(x => x.Id == id);
            if (deletedArtist == null)
            {
                return;
            }

            //_artistRepository.DeleteAsync(deletedArtist);
        }

        public async Task<IEnumerable<Artist>> GetAllArtistAsync()
        {
            return await _artistRepository.GetAllAsync();
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            var artist = await _artistRepository.GetByExpression(x => x.Id == id);

            if (artist == null)
            {
                return null;
            }

            return artist;
        }

        public async Task<Artist> UpdateArtistAsync(int id, Artist artist)
        {
            var updatedArtist = await _artistRepository.GetByExpression(x => x.Id == id);

            if (updatedArtist == null)
            {
                updatedArtist = new Artist()
                {
                    Id = artist.Id,
                    Name = artist.Name,
                };
            }
            else
            {
                updatedArtist.Id = artist.Id;
                updatedArtist.Name = artist.Name != null ? artist.Name : updatedArtist.Name;
            }

            var updated = await _artistRepository.UpdateAsync(updatedArtist);
            await _unitOfWork.CommitAsyc();


            return updated;
        }
    }
}
