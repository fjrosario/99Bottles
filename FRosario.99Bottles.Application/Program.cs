using System;

namespace FRosario.Bottles.App
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("How many bottles of beer?");

			string input = Console.ReadLine();

			int numBottles = 0;

			bool parseSuccess = int.TryParse(input, out numBottles);

			if (parseSuccess == false || numBottles < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(numBottles), "Number of bottles must be a valid integer that is 1 or greater");
			}
			else
			{
				Console.WriteLine($"{nameof(numBottles)} = {numBottles}");
			}

			var song = new Domain.BottlesSong(numBottles);

			Console.WriteLine(song.GetSong());


			Console.ReadKey();
		}
	}
}
