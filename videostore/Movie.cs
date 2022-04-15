using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videostore
{
	public class Movie
	{
		public const int CHILDRENS = 2;
		public const int REGULAR = 0;
		public const int NEW_RELEASE = 1;

		private String title;
		private int priceCode;

		public Movie(String title, int priceCode)
		{
			this.title = title;
			this.priceCode = priceCode;
		}

		public int getPriceCode()
		{
			return priceCode;
		}

		public void setPriceCode(int code)
		{
			priceCode = code;
		}

		public String getTitle()
		{
			return title;
		}

		public virtual double GetAmount(int daysRented)
		{
			double detailAmount = 0;
			// determines the amount for each line
			switch (getPriceCode())
			{
				case Movie.REGULAR:
					detailAmount += 2;
					if (daysRented > 2)
						detailAmount += (daysRented - 2) * 1.5;
					break;
				case Movie.NEW_RELEASE:
					detailAmount += daysRented * 3;
					break;
				case Movie.CHILDRENS:
					detailAmount += 1.5;
					if (daysRented > 3)
						detailAmount += (daysRented - 3) * 1.5;
					break;
			}

			return detailAmount;
		}

		public int GetPoints(int daysRented)
		{
			int points = 0;
			points++;

			if (getPriceCode() == Movie.NEW_RELEASE
					&& daysRented > 1)
				points++;

			return points;
		}
	}
}
