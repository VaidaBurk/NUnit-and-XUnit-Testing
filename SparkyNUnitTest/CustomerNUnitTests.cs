using NUnit.Framework;
using System;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        //Arrange
        private Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        public void CombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange

            //Act
            customer.GreetAndCombineNames("Ben", "Spark");

            //Assert
            //If there is a block of asserts in one test in case one assert fails others are not run. To run all asserts Assert.Multiple is used
            Assert.Multiple(() =>
            {
                Assert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
                Assert.That(customer.GreetMessage, Does.Contain("Ben")); //case sensitive
                Assert.That(customer.GreetMessage, Does.Contain("ben").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
                //regular expression
                //[A-Z]{1} --first symbol is any capital from A to Z
                //[a-z]+ --any number of letters (+ means any number)
                //  -- space
                // --and second word the same
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //arrange

            //act --no method is called, so greeting message is empty

            //assert
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnNotNull()
        {
            customer.GreetAndCombineNames("Ben", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrWhiteSpace(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            //option 1
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);

            //option 2
            Assert.That(() => customer.GreetAndCombineNames("", "Spark"),
                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            //Checking if exception was thrown
            //option 1
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            //option 2
            Assert.That(() => customer.GreetAndCombineNames("", "Spark"), Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Orders_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Orders_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
