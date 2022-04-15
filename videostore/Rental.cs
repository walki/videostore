using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videostore
{
    public class Rental
    {
		public Rental(Movie movie, int daysRented)
		{
			this.movie = movie;
			this.daysRented = daysRented;
		}

		public int getDaysRented()
		{
			return daysRented;
		}

		public Movie getMovie()
		{
			return movie;
		}

		private Movie movie;
		private int daysRented;

        internal int getPriceCode()
        {
			return movie.getPriceCode();
        }

        public double GetAmount()
        {
            double detailAmount = 0;
            // determines the amount for each line
            switch (getPriceCode())
            {
                case Movie.REGULAR:
                    detailAmount += 2;
                    if (getDaysRented() > 2)
                        detailAmount += (getDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    detailAmount += getDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    detailAmount += 1.5;
                    if (getDaysRented() > 3)
                        detailAmount += (getDaysRented() - 3) * 1.5;
                    break;
            }

            return detailAmount;
        }

        public int GetPoints()
        {
            int points = 0;
            points++;

            if (getPriceCode() == Movie.NEW_RELEASE
                    && getDaysRented() > 1)
                points++;

            return points;
        }

        public string getTitle()
        {
            return movie.getTitle();
        }
    }
}
