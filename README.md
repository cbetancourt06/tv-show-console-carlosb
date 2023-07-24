# TV Show Manager - CarlosB
This is a console application for managing a list of TV Shows. The application allows users to see the list of shows, mark as favorite, and filter TV Shows through the command console.

## What includes?
This solution includes 2 projects:
- The main project (console project), which you can run and use the TV show manager from a CMD terminal.
- A test project, which includes a couple of tests which test the logic functionality.

## How do I execute the program?
As a prerequiste, **you should clone this repo in your preferred folder in your local machine**. We asume you are using a Windows OS version, so, next instructions are based on this OS.

In a CMD prompt, navegate to your folder eg:
````console
$ cd /home/user/projects/tv-show-console-carlosb
````
Then cd to the console project folder:
````console
$ cd TVShowCarlosB/TVShowCarlosB
````
And finally run the `dotnet run` command. You'll see this in the prompt.
![Run the application](https://i.imgur.com/mJeyQsG.jpg "Menu")

## What options can I choose?
Once within the application, the options are:
- `list`: Will show the complete list of TV shows.
- `{ID}`: If you ener an ID (TV show identifier) this will mark/unmark as favorite the selected show.
- `favorites`: Will show only your favorite shows.
- `exit`: To quit the application.

## Where are the data come from?
I wrote the application to use an InMemory DB, so in the moment it runs, excutes a method to seed data on the DB. In the TvShowDbContextSeedData.cs file, you can see the code.

Here you have a snnipet:
````console
static string[] names = new string[] {
    "Exatlón", "Survivor México", "MasterChef", "Soy famoso",
    "La Casa de los Famosos", "Bety la Fea", "Me Caigo de Risa"
};

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
```` 
As you see, there is a list of Mexican TV Show. You can add or new shows or remove one of them.

## Run the test project.
In the solution explorer, you can right-click the test project and select **Run Test,** then watch the results in Text Explore.
![Run the tests](https://i.imgur.com/IG46Fez.jpg "Run test")

## But... What's the magic here?
This solution includes the using of very important programming concepts like:
- SOLID priniciples
- Design patterns: Dependency Injection and Repository mainly
- OOP concepts, eg Heritance

All in the same place :D
