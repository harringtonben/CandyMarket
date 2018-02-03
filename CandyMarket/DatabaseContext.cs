using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	internal class DatabaseContext
	{
		private int _countOfTaffy;
		private int _countOfCandyCoated;
		private int _countOfChocolateBar;
		private int _countOfZagnut;

        public Dictionary<string, int> CandyCounts = new Dictionary<string, int>();

		/**
		 * this is just an example.
		 * feel free to modify the definition of this collection "BagOfCandy" if you choose to implement the more difficult data model.
		 * Dictionary<CandyType, List<Candy>> BagOfCandy { get; set; }
		 */

		public DatabaseContext(int tone) => Console.Beep(tone, 2500);

		internal List<string> GetCandyTypes()
		{
			return Enum
				.GetNames(typeof(CandyType))
				.Select(candyType =>
					candyType.Humanize(LetterCasing.Title))
				.ToList();
		}

		internal void SaveNewCandy(char selectedCandyMenuOption)
		{
			var candyOption = int.Parse(selectedCandyMenuOption.ToString());

			var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
			var forRealTheCandyThisTime = (CandyType)candyOption;

			switch (forRealTheCandyThisTime)
			{
				case CandyType.TaffyNotLaffy:
					++_countOfTaffy;
					break;
				case CandyType.CandyCoated:
					++_countOfCandyCoated;
					break;
				case CandyType.CompressedSugar:
					++_countOfChocolateBar;
					break;
				case CandyType.ZagnutStyle:
					++_countOfZagnut;
					break;
				default:
					break;
			}
		}

        internal void EatCandy(char selectedCandyMenuOption)
        {
            var candyOption = int.Parse(selectedCandyMenuOption.ToString());

            var eatenCandy = (CandyType)candyOption;

            switch (eatenCandy)
            {
                case CandyType.TaffyNotLaffy:
                     --_countOfTaffy;
                    break;
                case CandyType.CandyCoated:
                    --_countOfCandyCoated;
                    break;
                case CandyType.CompressedSugar:
                    --_countOfChocolateBar;
                    break;
                case CandyType.ZagnutStyle:
                    --_countOfZagnut;
                    break;
                default:
                    break;
            }
        }

        internal void ThrowAwayCandy(char selectedCandyMenuOption)
        {
            var candyOption = int.Parse(selectedCandyMenuOption.ToString());

            var eatenCandy = (CandyType)candyOption;

            switch (eatenCandy)
            {
                case CandyType.TaffyNotLaffy:
                    _countOfTaffy = 0;
                    break;
                case CandyType.CandyCoated:
                    _countOfCandyCoated = 0;
                    break;
                case CandyType.CompressedSugar:
                    _countOfChocolateBar = 0;
                    break;
                case CandyType.ZagnutStyle:
                    _countOfZagnut = 0;
                    break;
                default:
                    break;
            }
        }

        internal Dictionary<string, int> GetCandyCounts()
        {
            CandyCounts.Clear();
            CandyCounts.Add("TaffyNotLaffy", _countOfTaffy);
            CandyCounts.Add("CandyCoated", _countOfCandyCoated);
            CandyCounts.Add("CompressedSugar", _countOfChocolateBar);
            CandyCounts.Add("ZagnutStyle", _countOfZagnut);

            return CandyCounts;
        }
    }
}