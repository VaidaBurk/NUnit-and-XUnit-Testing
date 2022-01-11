using NUnit.Framework;

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
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //arrange

            //act --no method is called, so greeting message is empty

            //assert
            Assert.IsNull(customer.GreetMessage);
        }
    }
}
