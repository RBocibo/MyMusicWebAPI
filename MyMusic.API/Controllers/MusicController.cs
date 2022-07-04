using Microsoft.AspNetCore.Mvc;
using MyMusic.Core.Models;
using MyMusic.Services;

namespace MyMusic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private IMusicService _musicService;
        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMusic()
        {
            var music = await _musicService.GetAllMusicAsync();
            return Ok(music);
        }

        [HttpPost]
        public async Task<Music> AddMusic(Music music)
        {
            var newMusic = await _musicService.CreateMusicAsync(music);
            return newMusic;
        }

        [HttpDelete("{id}")]
        public async Task DeleteMusic(int id)
        {
            await _musicService.DeleteMusicAsync(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var music = await _musicService.GetMusicByIdAsyc(id);
            return Ok(music);
        }

        [HttpPut]
        public async Task<IActionResult> PutById(int id, Music music)
        {
            var updateMusic = await _musicService.UpdateMusicAsync(id, music);
            return Ok(updateMusic);
        }
    }
}
