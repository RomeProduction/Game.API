using IGDB.API;
using RAWG.API;
using System;
using System.Linq;

namespace TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			//IgdbClient client = new IgdbClient("c932f03c6dde0559af87cb509bb5ff8a");
			//var games = client.GetGames();
			//Console.WriteLine($"Count of games: " + games.Count());
			RawgClient rawgClient = new RawgClient("TestApp");
			var rGames = rawgClient.GetGames();
			Console.WriteLine($"Count of games: " + rGames.Count());
			Console.ReadLine();
		}
	}
}
