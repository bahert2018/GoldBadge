using System;
using System.Collections.Generic;

namespace _01_Challenge
{
    class ProgramUI
    {
        private List<MenuItem> _menu;
        MenuItem menuItem = new MenuItem();
        MenuItemRepository _repo = new MenuItemRepository();

        public void Run()
        {
            bool userContinue = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Hello, what would you like to change today?" + "Please select one of the following actions:\n" +
                    "1) Add new menu item \n" +
                    "2) Remove menu item \n" +
                    "3) view menu \n" +
                    "4) exit ");
                int userSelection = int.Parse(Console.ReadLine());

                switch (userSelection)
                {
                    case 1:
                        AddMenuItem();
                        break;

                    case 2:
                        RemoveMenuItem();
                        break;

                    case 3:
                        ShowMenuItems();
                        break;

                    case 4:
                        userContinue = false;
                            break;

                    default:

                        break;
                }
            }
            while (userContinue);
        }



        private void AddMenuItem()
        {

            Console.WriteLine("What is the name of the item you would like to add?");
            string name = Console.ReadLine();

            Console.WriteLine("What number would you like to give this item");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("How much does this item cost?");
            decimal price = decimal.Parse(Console.ReadLine());
            
            Console.WriteLine("What is this item made of?");
            string ingredients = Console.ReadLine();

            Console.WriteLine("What is the description of this item?");
            string info = Console.ReadLine();

            MenuItem item = new MenuItem(name, number, price, info, ingredients);
            _repo.AddMenuItemToList(item);

        }


        private void RemoveMenuItem()
        {
            Console.Clear();
            ShowMenuItems();

            Console.WriteLine("What item would you like to remove from the list?");
            string name = Console.ReadLine();

            Console.WriteLine("What is the number of the item you would like to remove?");
            int number = int.Parse(Console.ReadLine());
            
            bool success = _repo.RemoveItemBySpecifications(name, number);
            if(success == true)
            {
                Console.WriteLine($"The order {name} was successfully removed.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"The order {name} was unable to be removed at this time.");
                Console.ReadKey();
                Console.Clear();
                ShowMenuItems();
            }   
        }


        private void ShowMenuItems()
        {
            _menu = _repo.GetMenuItems();
            foreach (MenuItem item in _menu)
            {
            Console.WriteLine($"{item.Name} {item.Number} {item.Price} {item.Ingredients} {item.Info}");
            }

            Console.ReadKey();
        }

        private int ParseInput()
        {
            int input = int.Parse(Console.ReadLine());
            if (input < 1 || input > 4)
            {
                Console.WriteLine("Your input was invalid, please enter a valid menu number.");
                input = ParseInput();
            }
            return input;
        }
    }
}   