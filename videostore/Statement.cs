using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videostore
{
    public class Statement
    {
        private String customerName;
        private List<Rental> rentals = new List<Rental>();

        public Statement(String customerName)
        {
            this.customerName = customerName;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public String GetCustomerName()
        {
            return customerName;
        }

        public String GenerateFormattedStatement()
        {
            return GenerateHeader()
                    + GenerateDetails()
                    + GenerateFooter();
        }


        private string GenerateHeader()
        {
            return "Rental Record for " + GetCustomerName() + "\n";
        }

        private string GenerateDetails()
        {
            return rentals.Aggregate("",
                 (result, rental) =>
                    result += "\t" + rental.getTitle() + "\t"
                    + String.Format("{0:0.00}", rental.GetAmount()) + "\n");
        }

        private string GenerateFooter()
        {
            return "You owed " + String.Format("{0:0.00}", GetStatementAmount()) + "\n"
                    + "You earned " + GetStatementPoints() + " frequent renter points\n";
        }

        internal int GetStatementPoints()
        {
            return rentals.Sum(r => r.GetPoints());
        }

        internal double GetStatementAmount()
        {
            return rentals.Sum(r => r.GetAmount());
        }

    }
}
