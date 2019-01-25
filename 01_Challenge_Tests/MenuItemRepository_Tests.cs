using System;
using _01_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class ObjectRepository_Tests
    {
        [TestMethod]
        public void MyObjectRepository_AddItemToList_ShoudBeCorrectString()
        {
            //Arrange
            MenuItemRepository _repo = new MenuItemRepository();
            MenuItem name = new MenuItem();
            MenuItem number = new MenuItem();
            MenuItem price = new MenuItem();
            MenuItem ingredients = new MenuItem();
            MenuItem info = new MenuItem();

            _repo.AddMenuItemToList(name);
            _repo.AddMenuItemToList(number);
            _repo.AddMenuItemToList(price);
            _repo.AddMenuItemToList(ingredients);
            _repo.AddMenuItemToList(info);
            //Act

            int actual = _repo.GetMenuItems().Count;
            int expected = 5;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
    }
}
