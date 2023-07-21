using TVShowCarlosB.Models;

namespace TVShowCarlosB.Service
{
    /// <summary>
    /// Interface that implements all methods declared in the repository class
    /// </summary>
    public interface ITvShowService    {
        Task<IEnumerable<TvShow>> GetAllTvShows();

        Task<IEnumerable<TvShow>> GetFavoriteTvShows();

        string UpdateTvShow(int showId);
    }
}
