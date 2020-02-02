using System;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;

namespace dotnet_mlb
{
    class Program
    {
        private const int CriticalError = -1;
        private const int Success = 0;

        private const string AmericanLeagueName = "American League";
        private const string NationalLeagueName = "National League";

        static readonly string[] alEastTeams = new string[] { "Baltimore Orioles", "Boston Red Sox", "New York Yankees", "Tampa Bay Rays", "Toronto Blue Jays" };
        static readonly string[] alCentralTeams = new string[] { "Chicago White Sox", "Cleveland Indians", "Detroit Tigers", "Kansas City Royals", "Minnesota Twins" };
        static readonly string[] alWestTeams = new string[] { "Houston Astros", "Los Angeles Angels", "Oakland Athletics", "Seattle Mariners", "Texas Rangers" };
        static readonly string[] nlEastTeams = new string[] { "Atlanta Braves", "Miami Marlins", "New York Mets", "Philadelphia Phillies", "Washington Nationals" };
        static readonly string[] nlCentralTeams = new string[] { "Chicago Cubs", "Cincinnati Reds", "Milwaukee Brewers", "Pittsburgh Pirates", "St. Louis Cardinals" };
        static readonly string[] nlWestTeams = new string[] { "Arizona Diamondbacks", "Colorado Rockies", "Los Angeles Dodgers", "San Diego Padres", "San Francisco Giants" };

        static int Main(string[] args)
        {
            try
            {
                var app = new CommandLineApplication
                {
                    Name = "dotnet mlb"
                };

                app.Command("leagues", config =>
                {
                    config.HelpOption("-h|--help");

                    config.OnExecute(() =>
                    {
                        Console.WriteLine(AmericanLeagueName);
                        Console.WriteLine(NationalLeagueName);
                        return Success;
                    });
                });

                app.Command("teams", config =>
                {
                    config.HelpOption("-h|--help");

                    var league = config.Option(
                        "-l|--league",
                        "Two options (\"al\", \"nl\") can be specified",
                        CommandOptionType.SingleValue);

                    config.OnExecute(() =>
                    {
                        if (!league.HasValue())
                        {
                            Console.WriteLine("A league must be specified.");
                            return CriticalError;
                        }

                        switch (league.Value())
                        {
                            case "al":
                                foreach (var team in alEastTeams)
                                {
                                    Console.WriteLine(team);
                                }
                                foreach (var team in alCentralTeams)
                                {
                                    Console.WriteLine(team);
                                }
                                foreach (var team in alWestTeams)
                                {
                                    Console.WriteLine(team);
                                }
                                break;

                            case "nl":
                                foreach (var team in nlEastTeams)
                                {
                                    Console.WriteLine(team);
                                }
                                foreach (var team in nlCentralTeams)
                                {
                                    Console.WriteLine(team);
                                }
                                foreach (var team in nlWestTeams)
                                {
                                    Console.WriteLine(team);
                                }
                                break;

                            default:
                                Console.WriteLine("A league must be specified (\"al\" or \"nl\").");
                                return CriticalError;
                        }

                        return Success;
                    });
                });

                app.HelpOption("-h|--help");

                app.OnExecute(() =>
                {
                    app.ShowHelp();
                    return Success;
                });

                return app.Execute(args);
            }
            catch (System.Exception)
            {
                return CriticalError;
            }
        }
    }
}
