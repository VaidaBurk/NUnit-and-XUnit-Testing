using System;
using Xunit;

namespace Sparky
{
    public class CustomerXUnitTests
    {
        private Customer customer;
        public CustomerXUnitTests()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange

            //Act
            customer.GreetAndCombineNames("Ben", "Spark");

            //Assert
                Assert.Equal("Hello, Ben Spark", customer.GreetMessage);
                Assert.Contains("Ben", customer.GreetMessage); //case sensitive
                Assert.Contains("ben".ToLower(), customer.GreetMessage.ToLower());
                Assert.StartsWith("Hello", customer.GreetMessage);
                Assert.EndsWith("Spark", customer.GreetMessage);
                Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
                //regular expression
                //[A-Z]{1} --first symbol is any capital from A to Z
                //[a-z]+ --any number of letters (+ means any number)
                //  -- space
                // --and second word the same
        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //arrange

            //act --no method is called, so greeting message is empty

            //assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnNotNull()
        {
            customer.GreetAndCombineNames("Ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrWhiteSpace(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            //option 1
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);

            //Checking if exception was thrown
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Orders_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Orders_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
