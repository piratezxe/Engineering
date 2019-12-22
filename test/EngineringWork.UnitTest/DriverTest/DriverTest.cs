using System;
using EngineeringWork.Core.Domain;
using FluentAssertions;
using Xunit;

namespace EngineringWork.UnitTest.DriverTest
{
    public class DriverTest
    {
        [Fact]
        public void when_change_user_phone_number_and_is_empty_should_throw_exception()
        {
            var driver = new Driver(Guid.NewGuid(), "533699746");

            Action action = () => driver.SetPhoneNumber(string.Empty);

            action.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void when_change_user_phone_number_and_is_empty_should_throw_exception_and_dont_change_property()
        {
            var driver = new Driver(Guid.NewGuid(), "533699746");

            Action action = () => driver.SetPhoneNumber(string.Empty);

            action.Should().Throw<ArgumentException>();

            driver.PhoneNumber.Should().BeEquivalentTo(string.Empty);
        }

        [Fact]
        public void when_invoke_set_driver_phone_number_and_is_valid_should_change_number()
        {
            var driver = new Driver(Guid.NewGuid(), "123");

            var newPhoneNumber = "53123123";
            
            driver.SetPhoneNumber(newPhoneNumber);
            driver.PhoneNumber.Should().BeEquivalentTo(newPhoneNumber);
        }
    }
}