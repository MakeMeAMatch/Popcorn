using Microsoft.AspNetCore.Mvc;
using Popcorn.Controllers;
using Popcorn.Models;
using System;
using Xunit;

namespace PopcornTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateUser()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void CanChangeFirstName()
        {
            // Arrange
            var m = new User { FirstName = "John" };

            //Act
            m.FirstName = "Tom";

            //Assert
            Assert.Equal("Tom", m.FirstName);
        }

        [Fact]
        public void DOBIsDateTime()
        {
            // Arrange
            var p = new User();

            //Act
            p.DateOfBirth = (new DateTime(1989, 8, 18));

            //Assert
            Assert.IsType<DateTime>(p.DateOfBirth);
        }

        [Fact]
        public void CanChangeDOB()
        {
            // Arrange
            var p = new User { DateOfBirth = (new DateTime(1999, 12, 14)) };

            //Act
            p.DateOfBirth = (new DateTime(1989, 8, 18));

            //Assert
            Assert.Equal((new DateTime(1989, 8, 18)), p.DateOfBirth);
        }

        [Fact]
        public void RememberMeIsBool()
        {
            // Arrange
            var p = new LoginViewModel();

            //Act
            p.RememberMe = false;

            //Assert
            Assert.IsType<bool>(p.RememberMe);
        }

        [Fact]
        public void CanChangeRememberMe()
        {
            // Arrange
            var m = new LoginViewModel { RememberMe = false };

            //Act
            m.RememberMe = true;

            //Assert
            Assert.True(m.RememberMe);
        }

        [Fact]
        public void FullNameIsString()
        {
            // Arrange
            var p = new User();

            //Act
            p.FullName = "Clark Kent";

            //Assert
            Assert.IsType<string>(p.FullName);
        }

        [Fact]
        public void CanChangeFullName()
        {
            // Arrange
            var m = new User { FullName = "Clark Kent" };

            //Act
            m.FullName = "Bruce Wayne";

            //Assert
            Assert.Equal("Bruce Wayne", m.FullName);
        }

        [Fact]
        public void HomeIndexResultIsView()
        {
            var controller = new Popcorn.Controllers.HomeController();

            //Arrange
            HomeController h = new Popcorn.Controllers.HomeController();

            //Act
            IActionResult result = h.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void PlaySpotsIsInt()
        {
            // Arrange
            var p = new User();

            //Act
            p.PlaySpots = 5;

            //Assert
            Assert.IsType<int>(p.PlaySpots);
        }

        [Fact]
        public void CanChangeNumberOfKids()
        {
            // Arrange
            var m = new User { NumberOfKids = 1 };

            //Act
            m.NumberOfKids = 2;

            //Assert
            Assert.Equal(2, m.NumberOfKids);
        }

        [Fact]
        public void PasswordIsString()
        {
            // Arrange
            var p = new RegisterViewModel();

            //Act
            p.Password = "password!23";

            //Assert
            Assert.IsType<string>(p.Password);
        }

        [Fact]
        public void CanChangePassword()
        {
            // Arrange
            var m = new RegisterViewModel { Password = "password!23" };

            //Act
            m.Password = "P@#$word!23";

            //Assert
            Assert.Equal("P@#$word!23", m.Password);
        }

    }
}
