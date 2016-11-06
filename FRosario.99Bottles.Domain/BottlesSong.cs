using System;
namespace FRosario.Bottles.Domain
{
	public class BottlesSong
	{

		public const int MinNumberOfBottles = 1;

		private readonly int _numBottlesAtStart = 0;
		public BottlesSong(int numBottles)
		{
			if (numBottles < MinNumberOfBottles)
			{
				throw new ArgumentOutOfRangeException(nameof(numBottles), $"Value must be an integer of {MinNumberOfBottles} or greater. Value given: {numBottles}");
			}

			_numBottlesAtStart = numBottles;
		}

		public string GetBottlesString(int numBottles)
		{
			if (numBottles == 1)
			{
				return "1 bottle";
			}
			else
			{
				return $"{numBottles} bottles";
			}
		}

		public string GetVerse(int curNumber) 
		{
			string verseString = null;
			if (curNumber >= 2)
			{
				verseString = $"{GetBottlesString(curNumber)} of beer on the wall,\n" +
				$"{GetBottlesString(curNumber)} of beer.\n" +
				"Take one down,\n" +
				"pass it around,\n" + 
				$"{GetBottlesString(curNumber - 1)} of beer on the wall.";
			}
			if (curNumber == 1)
			{ 
				verseString = $"{GetBottlesString(curNumber)} of beer on the wall,\n" +
				$"{GetBottlesString(curNumber)} of beer.\n" +
				"Take one down,\n" +
				"pass it around,\n" +
				"No more bottles of beer on the wall.";
			}
			if (curNumber == 0)
			{
				verseString = "No more bottles of beer on the wall, \n" +
					"No more bottles of beer.\n" + 
					"Go to the store,\n" + 
					"buy some more.\n" +
					$"{GetBottlesString(_numBottlesAtStart)} of beer on the wall.";
			}

			return verseString;
		}

		public string GetSong()
		{
			var sb = new System.Text.StringBuilder();

			for (int curBottle = _numBottlesAtStart; curBottle >= 0; curBottle--)
			{
				sb.AppendLine();
				sb.AppendLine(GetVerse(curBottle));
			}

			return sb.ToString().Trim();
		}
	}
}
