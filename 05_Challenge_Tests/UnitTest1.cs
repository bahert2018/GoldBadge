using System;
using _05_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_Challenge_Tests
{
    [TestClass]
    public class _05_Challenge_Tests
    {
        [TestMethod]
        public void _05_Challenge_AddCustomerToList_ShouldBeCorrectCount()
        {
            //Arrange
            EmailProgramRepository _emailRepo = new EmailProgramRepository();
            EmailProgram firstName = new EmailProgram(CustomerData.NewCustomers,"Who", "Me", "who.me.com");
            EmailProgram lastName = new EmailProgram();
            EmailProgram email = new EmailProgram();
            //CustomerData type = CustomerData.OldCustomers;

            _emailRepo.AddEmailProgramToList(firstName);
            _emailRepo.AddEmailProgramToList(lastName);
            _emailRepo.AddEmailProgramToList(email);
            //Act

            int actual = _emailRepo.GetEmailProgram().Count;
            int expected = 3;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void _05_Challenge_RemoveCustomerFromList_ShouldBeCorrectCount()
        {
            //Arrange
            EmailProgramRepository _emailRepo = new EmailProgramRepository();
            EmailProgram firstName = new EmailProgram();
            EmailProgram lastName = new EmailProgram();
            EmailProgram email = new EmailProgram();

            _emailRepo.AddEmailProgramToList(firstName);
            _emailRepo.AddEmailProgramToList(lastName);
            _emailRepo.AddEmailProgramToList(email);
            _emailRepo.RemoveCustomerEmail(firstName);
            //Act

            int actual = _emailRepo.GetEmailProgram().Count;
            int expected = 2;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void _05_Challenge_RemoveCustomerBySpecification_ShouldBeCorrectCount()
        {
            //Arrange
            EmailProgramRepository _emailRepo = new EmailProgramRepository();
            EmailProgram firstName = new EmailProgram(CustomerData.NewCustomers, "Who", "Me", "Who.me@where.com");


            _emailRepo.AddEmailProgramToList(firstName);
            _emailRepo.RemoveCustomerBySpecifications("Who", "Me", "Who.me@where.com");

            //Act

            int actual = _emailRepo.GetEmailProgram().Count;
            int expected = 0;

            //Assert
            Assert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void _05_Challenge_UpdateCustomerInfo_ShouldBeCorrectCount()

        {
            //Arrange
            EmailProgramRepository _emailRepo = new EmailProgramRepository();
            EmailProgram lastName = new EmailProgram(CustomerData.CurrentCustomers, "Why", "When", "why.me@world.com");
            EmailProgram firstName = new EmailProgram();
            EmailProgram LastName = new EmailProgram();
            EmailProgram email = new EmailProgram();


            _emailRepo.RemoveCustomerBySpecifications("Why", "When", "why.me@world.com");
            _emailRepo.AddEmailProgramToList(firstName);
            _emailRepo.AddEmailProgramToList(LastName);
            _emailRepo.AddEmailProgramToList(email);

            //Act
            int actual = _emailRepo.GetEmailProgram().Count;
            int expected = 3;


            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
