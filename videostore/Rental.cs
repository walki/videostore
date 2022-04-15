using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videostore
{
    public class Rental
    {
        private Movie movie;
        private int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public double GetAmount()
        {
            return movie.GetAmount(daysRented);
        }

        public int GetPoints()
        {
            return movie.GetPoints(daysRented);
        }

        public string getTitle()
        {
            return movie.GetTitle();
        }
    }
}
