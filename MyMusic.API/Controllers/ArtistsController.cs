using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Core.Models;
using MyMusic.Services;

namespace MyMusic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;
        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await _artistService.GetAllArtistAsync();
        }

        [HttpGet("{id}")]
        public async Task<Artist> GetArtistById(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            return artist;
        }

        [HttpPost]
        public async Task<Artist> PostArtist(Artist artist)
        {
            var newArtist = await _artistService.CreateArtist(artist);
            return newArtist;
        }

        [HttpPut]
        public async Task<Artist> PutArtist(int id,Artist artist)
        {
            return await _artistService.UpdateArtistAsync(id, artist);
        }
        [HttpDelete]
        public async Task RemoveArtist(int id)
        {
             await _artistService.DeleteArtist(id);
        }
    }
}
