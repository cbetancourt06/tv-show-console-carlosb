using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVShowCarlosB.Models;

namespace TVShowCarlosB.Service
{
    /// <summary>
    /// This is a repository class in which are stated all the needed logic for
    /// consulting, editing, etc.
    /// </summary>
    public class TvShowService : ITvShowService
    {
        private readonly TvShowDbContext _context;

        public TvShowService()
        {
            var options = new DbContextOptionsBuilder<TvShowDbContext>()
                .UseInMemoryDatabase("TVShows")
                .Options;

            _context = new TvShowDbContext(options);
        }

        public async Task<IEnumerable<TvShow>> GetAllTvShows() => await _context.TvShows.ToListAsync();

        public async Task<IEnumerable<TvShow>> GetFavoriteTvShows() => await _context.TvShows.Where(x => x.IsFavorite).ToListAsync();

        public string UpdateTvShow(int showId)
        {
            var tvShow = _context.TvShows.SingleOrDefault(x => x.Id == showId);
            if (tvShow != null)
            {
                bool isFavorite = tvShow.IsFavorite;
                tvShow.IsFavorite = !isFavorite;
                _context.SaveChanges();
                return "Updated succesfully!";
            }
            else
            {
                return "TV show does not exist.";
            }
        }
    }
}
