using Microsoft.Extensions.DependencyInjection;
using TVShowCarlosB.Models;
using TVShowCarlosB.Service;


namespace TVShowCarlosB
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ITvShowService, TvShowService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<ITvShowService>();

            Console.WriteLine("Welcome to the TV Shows manager. Next, you'll see the TV shows list\n");
            Console.WriteLine("-----TV Shows List-----");
            PrintList(await service.GetAllTvShows());

            Console.WriteLine("\nThe menu options are:");
            Console.WriteLine("list: To show the complete list of TV shows.");
            Console.WriteLine("{ID}: Enter the ID (TV show identifier) to mark/unmark as favorite a show.");
            Console.WriteLine("favorites: To show all your favorite shows.");
            Console.WriteLine("exit: To exit from the application.");

            string option = "";

            while (true)
            {
                Console.Write("\nType option: ");
                option = Console.ReadLine();
                int id;

                if(option.ToLower() == "list")
                {
                    Console.WriteLine("-----TV Shows List-----");
                    PrintList(await service.GetAllTvShows());
                }
                else if (option.ToLower() == "favorites")
                {
                    Console.WriteLine("-----Favorite Shows List-----");
                    PrintList(await service.GetFavoriteTvShows());
                }
                else if (int.TryParse(option, out id))
                {
                    Console.WriteLine(service.UpdateTvShow(id).ToString());
                }
                else if(option.ToLower() == "exit")
                {
                    Console.WriteLine("See you next time. I'll miss you!");
                    Environment.Exit(0);
                }                
                else
                {
                    Console.WriteLine("Invalid option. Try again.");
                }
            }
        }

        private static void PrintList(IEnumerable<TvShow> tvShows)
        {
            Console.WriteLine($"ID\tName");
            foreach (var tvShow in tvShows)
            {
                Console.Write($"{tvShow.Id}\t{tvShow.Title}");
                if (tvShow.IsFavorite)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
    }
}