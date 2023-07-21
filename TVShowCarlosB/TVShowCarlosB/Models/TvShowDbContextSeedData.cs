using System;
using System.Linq;

namespace TVShowCarlosB.Models
{
    public static class TvShowDbContextSeedData
    {
        static object synchlock = new object();
        static volatile bool seeded = false;
        static string[] names = new string[] {
            "Exatlón", "Survivor México", "MasterChef", "Soy famoso",
            "La Casa de los Famosos", "Bety la Fea", "Me Caigo de Risa"
        };

        public static void EnsureSeedData(this TvShowDbContext context)
        {
            if (!seeded && context.TvShows.Count() == 0)
            {
                lock (synchlock)
                {
                    if (!seeded)
                    {
                        var tvShows = GenerateTvShows();

                        context.TvShows.AddRange(tvShows);

                        context.SaveChanges();
                        seeded = true;
                    }
                }
            }
        }

        #region Data
        public static TvShow[] GenerateTvShows()
        {
            TvShow[] tvShows = new TvShow[names.Length];
            var random = new Random();

            for (int i = 0; i < tvShows.Length; i++)
            {
                tvShows[i] = new TvShow()
                {
                    Title = names[i],
                    IsFavorite = random.Next(2) == 1
                };
            }
            return tvShows;
        }        

        #endregion
    }
}
