using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videostore
{
    public class Customer
    {
        private String name;
		private List<Rental> rentals = new List<Rental>();
        private double totalAmount;
        private int frequentRenterPoints;

        public Customer(String name)
		{
			this.name = name;
		}

		public void AddRental(Rental rental)
		{
			rentals.Add(rental);
		}

		public String GetName()
		{
			return name;
		}

		public String GenerateFormattedStatement()

		{
			String result = "Rental Record for " + GetName() + "\n";

			foreach (Rental rental in rentals)
            {
                double rentalAmount = rental.GetAmount();

                DetermineRentalPoints(rental);

                result += "\t" + rental.getMovie().getTitle() + "\t"
                                    + String.Format("{0:0.00}", rentalAmount) + "\n";
                totalAmount += rentalAmount;

            }

            result += "You owed " + String.Format("{0:0.00}", totalAmount) + "\n";
			result += "You earned " + frequentRenterPoints + " frequent renter points\n";


			return result;
		}

        private void DetermineRentalPoints(Rental rental)
        {
            frequentRenterPoints++;

            if (rental.getMovie().getPriceCode() == Movie.NEW_RELEASE
                    && rental.getDaysRented() > 1)
                frequentRenterPoints++;
        }



        internal int GetPoints()
        {
			return frequentRenterPoints;
        }

        internal double GetAmount()
        {
            return totalAmount;
        }

    }
}
