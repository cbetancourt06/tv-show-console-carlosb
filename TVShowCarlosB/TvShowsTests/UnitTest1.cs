using Microsoft.Extensions.DependencyInjection;
using TVShowCarlosB.Models;
using TVShowCarlosB.Service;

namespace TvShowsTests
{
    public class UnitTest1
    {

        [Fact]
        public async Task TestGetAllTvShowsAsync()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ITvShowService, TvShowService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<ITvShowService>();

            var result = await service.GetAllTvShows();
            var expected = new List<TvShow>();

            Assert.NotEqual(expected, result);
        }

        [Fact]
        public async Task TestGetFavoriteTvShows()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ITvShowService, TvShowService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<ITvShowService>();

            var result = await service.GetFavoriteTvShows();
            var expected = new List<TvShow>();

            Assert.NotEqual(expected, result);
        }

        [Fact]
        public async Task TestUpdateTvShow()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ITvShowService, TvShowService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<ITvShowService>();

            var result = service.UpdateTvShow(1);

            Assert.IsType<string>(result);
        }
    }
}