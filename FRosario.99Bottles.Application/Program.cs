using System;

namespace FRosario.Bottles.Application
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("How many bottles of beer?");

			string input = Console.ReadLine();

			int numBottles = 0;

			bool parseSuccess = int.TryParse(input, out numBottles);

			if (parseSuccess == false || numBottles < Domain.BottlesSong.MinNumberOfBottles)
			{
				throw new ArgumentOutOfRangeException(nameof(numBottles), $"Number of bottles must be a valid integer that is {Domain.BottlesSong.MinNumberOfBottles} or greater");
			}
			else
			{
				Console.WriteLine($"{nameof(numBottles)} = {numBottles}\n\n");
			}

			var song = new Domain.BottlesSong(numBottles);

			Console.WriteLine(song.GetSong());


			Console.ReadKey();
		}
	}
}
