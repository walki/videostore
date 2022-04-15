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
        private Customer customer;
        private Movie NewRelease1 = new Movie("New Release 1", Movie.NEW_RELEASE);
        private Movie NewRelease2 = new Movie("New Release 2", Movie.NEW_RELEASE);
        private Movie Childrens1 = new Movie("Childrens 1", Movie.CHILDRENS);
        private Movie Regular1 = new Movie("Regular 1", Movie.REGULAR);
        private Movie Regular2 = new Movie("Regular 2", Movie.REGULAR);
        private Movie Regular3 = new Movie("Regular 3", Movie.REGULAR);

        [SetUp]
        protected void SetUp()
        {
            customer = new Customer("Customer Name");
        }

        [Test]
        public void SingleNewReleaseStatement()
        {
            customer.addRental(new Rental(NewRelease1, 3));
            customer.statement();
            
            AssertAmountOwedAndRenterPoints(9.00, 2);
        }

        [Test]
        public void DualNewReleaseStatement()
        {
            customer.addRental(new Rental(NewRelease1, 3));
            customer.addRental(new Rental(NewRelease2, 3));
            customer.statement();

            AssertAmountOwedAndRenterPoints(18.00, 4);
        }

        [Test]
        public void SingleChildrensStatement()
        {
            customer.addRental(new Rental(Childrens1, 3));
            customer.statement();

            AssertAmountOwedAndRenterPoints(1.50, 1);
        }

        [Test]
        public void MultipleRegularStatement()
        {
            customer.addRental(new Rental(Regular1, 1));
            customer.addRental(new Rental(Regular2, 2));
            customer.addRental(new Rental(Regular3, 3));

            Assert.That(customer.statement(), Is.EqualTo("Rental Record for Customer Name\n" +
                                                        "\tRegular 1\t2.00\n" +
                                                        "\tRegular 2\t2.00\n" +
                                                        "\tRegular 3\t3.50\n" +
                                                        "You owed 7.50\n" +
                                                        "You earned 3 frequent renter points\n"));
            AssertAmountOwedAndRenterPoints(7.50, 3);
        }

        private void AssertAmountOwedAndRenterPoints(double owed, int points)
        {
            Assert.That(customer.getAmount(), Is.EqualTo(owed).Within(0.000001));
            Assert.That(customer.getPoints(), Is.EqualTo(points));
        }

    }
}
