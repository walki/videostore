using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videostore
{
    [TestFixture]
    public class VideoStoreTest
    {
        private Statement customer;
        private Movie NewRelease1;
        private Movie NewRelease2;
        private Movie Childrens1;
        private Movie Regular1;
        private Movie Regular2;
        private Movie Regular3;

        [SetUp]
        protected void SetUp()
        {
            customer = new Statement("Customer Name");
            NewRelease1 = new Movie("New Release 1", Movie.NEW_RELEASE);
            NewRelease2 = new Movie("New Release 2", Movie.NEW_RELEASE);
            Childrens1 = new Movie("Childrens 1", Movie.CHILDRENS);
            Regular1 = new Movie("Regular 1", Movie.REGULAR);
            Regular2 = new Movie("Regular 2", Movie.REGULAR);
            Regular3 = new Movie("Regular 3", Movie.REGULAR);
        }

        [Test]
        public void SingleNewReleaseStatement()
        {
            customer.AddRental(new Rental(NewRelease1, 3));
            
            AssertAmountOwedAndRenterPoints(9.00, 2);
        }

        [Test]
        public void DualNewReleaseStatement()
        {
            customer.AddRental(new Rental(NewRelease1, 3));
            customer.AddRental(new Rental(NewRelease2, 3));

            AssertAmountOwedAndRenterPoints(18.00, 4);
        }

        [Test]
        public void SingleChildrensStatement()
        {
            customer.AddRental(new Rental(Childrens1, 3));
            
            AssertAmountOwedAndRenterPoints(1.50, 1);
        }

        [Test]
        public void MultipleRegularStatement()
        {
            customer.AddRental(new Rental(Regular1, 1));
            customer.AddRental(new Rental(Regular2, 2));
            customer.AddRental(new Rental(Regular3, 3));

            Assert.That(customer.GenerateFormattedStatement(), Is.EqualTo("Rental Record for Customer Name\n" +
                                                        "\tRegular 1\t2.00\n" +
                                                        "\tRegular 2\t2.00\n" +
                                                        "\tRegular 3\t3.50\n" +
                                                        "You owed 7.50\n" +
                                                        "You earned 3 frequent renter points\n"));
            AssertAmountOwedAndRenterPoints(7.50, 3);
        }

        private void AssertAmountOwedAndRenterPoints(double owed, int points)
        {
            Assert.That(customer.GetStatementAmount(), Is.EqualTo(owed).Within(0.000001));
            Assert.That(customer.GetStatementPoints(), Is.EqualTo(points));
        }

    }
}
