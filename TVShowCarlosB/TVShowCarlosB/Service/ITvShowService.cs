using TVShowCarlosB.Models;

namespace TVShowCarlosB.Service
{
    public interface ITvShowService    {
        Task<IEnumerable<TvShow>> GetAllTvShows();

        Task<IEnumerable<TvShow>> GetFavoriteTvShows();

        string UpdateTvShow(int showId);
    }
}
