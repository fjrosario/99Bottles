using System;
namespace FRosario.Bottles.Domain
{
	public class BottlesSong
	{

		private readonly int _numBottlesAtStart = 0;
		public BottlesSong(int numBottles)
		{
			if (numBottles < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(numBottles), $"Value must be an integer of 0 or greater. Value given: {numBottles}");
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
			if (curNumber > 2)
			{
				verseString = $@"{GetBottlesString(curNumber)} of beer on the wall, 
				{GetBottlesString(curNumber)} of beer.
				Take one down,
				pass it around,
				{GetBottlesString(curNumber - 1)} of beer on the wall.";
			}
			if (curNumber == 1)
			{ 
				verseString = $@"{GetBottlesString(curNumber)} of beer on the wall, 
				{GetBottlesString(curNumber)} of beer.
				Take one down,
				pass it around,
				No more bottles of beer on the wall.";
			}
			if (curNumber == 0 && _numBottlesAtStart > 0)
			{
				verseString = $@"No more bottles of beer on the wall, 
				No more bottles of beer.
				Go to the store,
				buy some more.
				{GetBottlesString(_numBottlesAtStart)} of beer on the wall.";
			}

			return verseString;
		}

		public string GetSong()
		{
			var sb = new System.Text.StringBuilder();

			for (int curBottle = _numBottlesAtStart; curBottle >= 0; curBottle--)
			{
				sb.AppendLine(GetVerse(curBottle));
			}

			return sb.ToString();
		}
	}
}
