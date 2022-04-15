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
        private Movie NewRelease1 = new Movie("The Cell", Movie.NEW_RELEASE);
        private Movie NewRelease2 = new Movie("The Tigger Movie", Movie.NEW_RELEASE);
        private Movie Childrens1 = new Movie("The Tigger Movie", Movie.CHILDRENS);
        private Movie Regular1 = new Movie("Plan 9 from Outer Space", Movie.REGULAR);
        private Movie Regular2 = new Movie("8 1/2", Movie.REGULAR);
        private Movie Regular3 = new Movie("Eraserhead", Movie.REGULAR);

        [SetUp]
        protected void SetUp()
        {
            customer = new Customer("Fred");
        }

        [Test]
        public void SingleNewReleaseStatement()
        {
            customer.addRental(new Rental(NewRelease1, 3));
            Assert.That(customer.statement(), Is.EqualTo("Rental Record for Fred\n" +
                                                        "\tThe Cell\t9.00\n" +
                                                        "You owed 9.00\n" +
                                                        "You earned 2 frequent renter points\n"));
            Assert.That(customer.getAmount(), Is.EqualTo(9.00).Within(0.000001));
        }

        [Test]
        public void DualNewReleaseStatement()
        {
            customer.addRental(new Rental(NewRelease1, 3));
            customer.addRental(new Rental(NewRelease2, 3));
            Assert.That(customer.statement(), Is.EqualTo("Rental Record for Fred\n" +
                                                        "\tThe Cell\t9.00\n" +
                                                        "\tThe Tigger Movie\t9.00\n" +
                                                        "You owed 18.00\n" +
                                                        "You earned 4 frequent renter points\n"));
        }

        [Test]
        public void SingleChildrensStatement()
        {
            customer.addRental(new Rental(Childrens1, 3));
            Assert.That(customer.statement(), Is.EqualTo("Rental Record for Fred\n" +
                                                        "\tThe Tigger Movie\t1.50\n" +
                                                        "You owed 1.50\nYou earned 1 frequent renter points\n"));
        }

        [Test]
        public void MultipleRegularStatement()
        {
            customer.addRental(new Rental(Regular1, 1));
            customer.addRental(new Rental(Regular2, 2));
            customer.addRental(new Rental(Regular3, 3));

            Assert.That(customer.statement(), Is.EqualTo("Rental Record for Fred\n" +
                                                        "\tPlan 9 from Outer Space\t2.00\n" +
                                                        "\t8 1/2\t2.00\n" +
                                                        "\tEraserhead\t3.50\n" +
                                                        "You owed 7.50\n" +
                                                        "You earned 3 frequent renter points\n"));
        }

    }
}
