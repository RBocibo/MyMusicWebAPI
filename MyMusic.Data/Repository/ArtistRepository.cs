using MyMusic.Core.Interfaces;
using MyMusic.Core.Models;
using MyMusic.Data.DataContext;

namespace MyMusic.Data.Repository
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MyMusicDbContext dbContext) : base(dbContext)
        {
        }
    }
}
