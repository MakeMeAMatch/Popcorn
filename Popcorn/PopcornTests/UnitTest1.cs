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
            var m = new ApplicationUser { FirstName = "John" };

            //Act
            m.FirstName = "Tom";

            //Assert
            Assert.Equal("Tom", m.FirstName);
        }

        [Fact]
        public void LoginandRegisterPasswordsMatch()
        {
            // Arrange
            var p = new RegisterViewModel
            {
                //Act
                Password = "P@#$word!23"
            };

            var m = new LoginViewModel
            {
                //Act
                Password = "P@#$word!23"
            };

            //Assert
            Assert.Equal(p.Password, m.Password);
        }

        [Fact]
        public void DOBIsDateTime()
        {
            // Arrange
            var p = new ApplicationUser
            {

                //Act
                DateOfBirth = (new DateTime(1989, 8, 18))
            };

            //Assert
            Assert.IsType<DateTime>(p.DateOfBirth);
        }

        [Fact]
        public void CanChangeDOB()
        {
            // Arrange
            var p = new ApplicationUser { DateOfBirth = (new DateTime(1999, 12, 14)) };

            //Act
            p.DateOfBirth = (new DateTime(1989, 8, 18));

            //Assert
            Assert.Equal((new DateTime(1989, 8, 18)), p.DateOfBirth);
        }

        [Fact]
        public void RememberMeIsBool()
        {
            // Arrange
            var p = new LoginViewModel
            {

                //Act
                RememberMe = false
            };

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
            var p = new ApplicationUser
            {

                //Act
                FullName = "Clark Kent"
            };

            //Assert
            Assert.IsType<string>(p.FullName);
        }

        [Fact]
        public void CanChangeFullName()
        {
            // Arrange
            var m = new ApplicationUser { FullName = "Clark Kent" };

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
            var p = new ApplicationUser
            {

                //Act
                PlaySpots = "Park"
            };

            //Assert
            Assert.IsType<int>(p.PlaySpots);
        }

        [Fact]
        public void CanChangeNumberOfKids()
        {
            // Arrange
            var m = new ApplicationUser { NumberOfKids = 1 };

            //Act
            m.NumberOfKids = 2;

            //Assert
            Assert.Equal(2, m.NumberOfKids);
        }

        [Fact]
        public void PasswordIsString()
        {
            // Arrange
            var p = new RegisterViewModel
            {

                //Act
                Password = "password!23"
            };

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

        [Fact]
        public void CanChangeLastName()
        {
            // Arrange
            var m = new ApplicationUser { LastName = "Wayne" };

            //Act
            m.LastName = "Kent";

            //Assert
            Assert.Equal("Kent", m.LastName);
        }

        [Fact]
        public void NumberOfKidsIsInt()
        {
            // Arrange
            var p = new ApplicationUser
            {

                //Act
                NumberOfKids = 2
            };

            //Assert
            Assert.IsType<int>(p.NumberOfKids);
        }

        [Fact]
        public void EmailIsString()
        {
            // Arrange
            var p = new RegisterViewModel
            {

                //Act
                Email = "dad@gmail.com"
            };

            //Assert
            Assert.IsType<DateTime>(p.DateOfBirth);
        }

        [Fact]
        public void RegisterPasswordsMatch()
        {
            // Arrange
            var p = new RegisterViewModel
            {

                //Act
                Password = "P@#$word!23",
                ConfirmPassword = "P@#$word!23"
            };

            //Assert
            Assert.Equal(p.Password, p.ConfirmPassword);
        }

        [Fact]
        public void CityStateIsString()
        {
            // Arrange
            var p = new ApplicationUser
            {

                //Act
                CityState = "Seattle, WA"
            };

            //Assert
            Assert.IsType<string>(p.CityState);
        }

        [Fact]
        public void FullNamesMatch()
        {
            // Arrange
            var p = new RegisterViewModel
            {
                //Act
                FullName = "Diana Prince"
            };

            var m = new ApplicationUser
            {
                //Act
                FullName = "Diana Prince"
            };

            //Assert
            Assert.Equal(p.FullName, m.FullName);
        }

        [Fact]
        public void LoginandRegisterEmailsMatch()
        {
            // Arrange
            var p = new RegisterViewModel
            {
                //Act
                Email = "test@gmail.com"
            };

            var m = new LoginViewModel
            {
                //Act
                Email = "test@gmail.com"
            };

            //Assert
            Assert.Equal(p.Email, m.Email);
        }

        [Fact]
        public void ReligionIsInt()
        {
            // Arrange
            var p = new Responses
            {

                //Act
                Religion = 2
            };

            //Assert
            Assert.IsType<int>(p.Religion);
        }

        [Fact]
        public void PoliticsIsInt()
        {
            // Arrange
            var p = new Responses
            {

                //Act
                Politics = 1
            };

            //Assert
            Assert.IsType<int>(p.Politics);
        }

        [Fact]
        public void SportsIsInt()
        {
            // Arrange
            var p = new Responses
            {

                //Act
                Sports = 3
            };

            //Assert
            Assert.IsType<int>(p.Sports);
        }

        [Fact]
        public void DietIsInt()
        {
            // Arrange
            var p = new Responses
            {

                //Act
                Diet = 1
            };

            //Assert
            Assert.IsType<int>(p.Diet);
        }

        [Fact]
        public void EntertainmentIsInt()
        {
            // Arrange
            var p = new Responses
            {

                //Act
                Entertainment = 2
            };

            //Assert
            Assert.IsType<int>(p.Entertainment);
        }

        [Fact]
        public void HonestyIsInt()
        {
            // Arrange
            var p = new Responses
            {

                //Act
                HonestySpectrum = 1
            };

            //Assert
            Assert.IsType<int>(p.HonestySpectrum);
        }

        [Fact]
        public void CanChangeReligion()
        {
            // Arrange
            var m = new Responses { Religion = 2 };

            //Act
            m.Religion = 5;

            //Assert
            Assert.Equal(5, m.Religion);
        }

        [Fact]
        public void CanChangePolitics()
        {
            // Arrange
            var m = new Responses { Politics = 8 };

            //Act
            m.Politics = 10;

            //Assert
            Assert.Equal(10, m.Politics);
        }

        [Fact]
        public void CanChangeSports()
        {
            // Arrange
            var m = new Responses { Sports = 9 };

            //Act
            m.Sports = 7;

            //Assert
            Assert.Equal(7, m.Sports);
        }
    }
}
