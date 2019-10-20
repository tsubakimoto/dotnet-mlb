using System;
using System.Linq;

namespace dotnet_mlb
{
    class Program
    {
        static readonly string[] alEastTeams = new string[] { "Baltimore Orioles", "Boston Red Sox", "New York Yankees", "Tampa Bay Rays", "Toronto Blue Jays" };
        static readonly string[] alCentralTeams = new string[] { "Chicago White Sox", "Cleveland Indians", "Detroit Tigers", "Kansas City Royals", "Minnesota Twins" };
        static readonly string[] alWestTeams = new string[] { "Houston Astros", "Los Angeles Angels", "Oakland Athletics", "Seattle Mariners", "Texas Rangers" };
        static readonly string[] nlEastTeams = new string[] { "Atlanta Braves", "Miami Marlins", "New York Mets", "Philadelphia Phillies", "Washington Nationals" };
        static readonly string[] nlCentralTeams = new string[] { "Chicago Cubs", "Cincinnati Reds", "Milwaukee Brewers", "Pittsburgh Pirates", "St. Louis Cardinals" };
        static readonly string[] nlWestTeams = new string[] { "Arizona Diamondbacks", "Colorado Rockies", "Los Angeles Dodgers", "San Diego Padres", "San Francisco Giants" };

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("https://www.mlb.com/");
                return;
            }

            if (args.Contains("--teams"))
            {
                ShowTeams();
                return;
            }
        }

        static void ShowTeams()
        {
            Console.WriteLine("=== American League ===");

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

            Console.WriteLine();
            
            Console.WriteLine("=== National League ===");

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
        }
    }
}
