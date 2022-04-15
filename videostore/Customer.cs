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
                double detailAmount = determineDetailAmount(rental);

                determineRentalPoints(rental);

                result += "\t" + rental.getMovie().getTitle() + "\t"
                                    + String.Format("{0:0.00}", detailAmount) + "\n";
                totalAmount += detailAmount;

            }

            result += "You owed " + String.Format("{0:0.00}", totalAmount) + "\n";
			result += "You earned " + frequentRenterPoints + " frequent renter points\n";


			return result;
		}

        private void determineRentalPoints(Rental rental)
        {
            frequentRenterPoints++;

            if (rental.getMovie().getPriceCode() == Movie.NEW_RELEASE
                    && rental.getDaysRented() > 1)
                frequentRenterPoints++;
        }

        private static double determineDetailAmount(Rental each)
        {
            double detailAmount = 0;
            // determines the amount for each line
            switch (each.getMovie().getPriceCode())
            {
                case Movie.REGULAR:
                    detailAmount += 2;
                    if (each.getDaysRented() > 2)
                        detailAmount += (each.getDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    detailAmount += each.getDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    detailAmount += 1.5;
                    if (each.getDaysRented() > 3)
                        detailAmount += (each.getDaysRented() - 3) * 1.5;
                    break;
            }

            return detailAmount;
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
