using System;
using System.Collections.Generic;




/*For their current customers, they want to send an appreciation email, something that says this:
"Thank you for your work with us. We appreciate your loyalty. Here's a coupon."

For past customers, they want to send a note that says something like this:
"It's been a long time since we've heard from you, we want you back".

For potential customers who have never worked with Komodo, they want to send an email
that simply states what deals Komodo is currently offering. It would be something like this:
"We currently have the lowest rates on Helicopter Insurance!"

Along with defining the proper class for a customer, your task will be to make 
an application that allows administrators to do CRUD methods: create, read, update, and delete
details about individual customers. 

List View
In addition to CRUD options, an administrator needs to show all customers in alphabetical order in a list like this:

FirstName  LastName  Type        Email
Jake        Smith     Potential   We currently have the lowest rates on Helicopter Insurance!
James       Smith     Current     Thank you for your work with us. We appreciate your loyalty. Here's a coupon.
Jane        Smith     Past        It's been a long time since we've heard from you, we want you back

Be sure to Unit Test your Repository methods.

Out of scope: Actually sending an email. We are just creating the string for the email. */



namespace _05_Challenge
{
    public class ProgramUI
    {
        private EmailProgramRepository _emailRepo;

        public ProgramUI()
        {
          _emailRepo = new EmailProgramRepository();
        }

        public void Run()
        {
            bool userContinue = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Hello, what would you like to do?" + "Please select one of the following actions:\n" +
                   "1) Create a new customer:\n" +
                   "2) Veiw Customer list \n" +
                   "3) Update Customer data \n" +
                   "4) Delete Customer \n" + 
                   "5) exit" );

                int userSelection = int.Parse(Console.ReadLine());

                switch (userSelection)
                {
                    case 1:
                        CreateNewCustomer();
                        break;

                    case 2:
                        ShowCustomerList();
                        break;

                    case 3:
                        UpdateCustomoerData();
                        break;

                    case 4:
                        DeleteCustomerData();
                            break;

                    case 5:
                        userContinue = false;
                        break;

                    default:

                        break;
                }
            }
            while (userContinue);
        }
       

        private void CreateNewCustomer()
        {
            Console.WriteLine("What is the first name?");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is the last name?");
            string lastName = Console.ReadLine();

            Console.WriteLine("What is the Type of customer? (1. Current / 2. Old / 3. New)");
            int input = int.Parse(Console.ReadLine());
            CustomerData type = CustomerData.CurrentCustomers;

            switch (input)
            {
                case 1:
                    type = CustomerData.CurrentCustomers;
                    break;

                case 2:
                    type = CustomerData.OldCustomers;
                    break;

                case 3:
                    type = CustomerData.NewCustomers;
                    break;
                        
            }

            Console.WriteLine("What is the Customer's Email?");
            string email = Console.ReadLine();

            EmailProgram program = new EmailProgram(type, firstName, lastName, email);
            _emailRepo.AddEmailProgramToList(program);
        }


        private void ShowCustomerList()
        {
            List<EmailProgram> customerlist = _emailRepo.GetEmailProgram();
            foreach(EmailProgram customer in customerlist)
            {
                if
                    (customer.Type == CustomerData.CurrentCustomers)
                {
                    Console.WriteLine($"Customer Type: {customer.Type}\n" +
                        $"Customer {customer.FirstName}" +
                        $"\n");
                    Console.WriteLine("Generic Email: \n" +
                        "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                }
                else if
                    (customer.Type == CustomerData.OldCustomers)
                {
                    Console.WriteLine($"Customer Type: {customer.Type}\n" +
                        $"customer {customer.FirstName}" + 
                        $"\n");
                    Console.WriteLine($"Generic Email: \n" +
                        "It's been a long time since we've heard from you, we want you back.");
                }
                else if
                    (customer.Type == CustomerData.NewCustomers)
                {
                    Console.WriteLine($"Customer Type: {customer.Type}\n" +
                        $"customer {customer.FirstName}" +
                        $"\n");
                    Console.WriteLine($"Generic Email: \n" +
                        "We currently have the lowest rates on Helicopter Insurance!");
                }
                else
                {
                    Console.WriteLine("Your input was not recognized.");
                    Console.ReadLine();
                    Console.Clear();
                    ShowCustomerList();
                }
                Console.WriteLine("Press any botten to continue");
                Console.ReadLine();
            }
        }


        private void UpdateCustomoerData()
        {
            Console.WriteLine("What is the Customer's FirstName?");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is the customer's LastName?");
            string lastName = Console.ReadLine();

            Console.WriteLine("What is the customer's Email?");
            string email = Console.ReadLine();

            EmailProgram customerEamil = _emailRepo.GetEmailProgram(firstName, lastName);

            Console.WriteLine("What is the new firstname?");
            customerEamil.FirstName = Console.ReadLine();

            Console.WriteLine("What is the customer's new lastname?");
            customerEamil.LastName = Console.ReadLine();

            Console.WriteLine("What is the customer's new Email?");
            customerEamil.Email = Console.ReadLine();

            Console.WriteLine("What is the new customer type? \n +" +
                "1. Current \n +" +
                "2. Old \n +" +
                "3. New");
            string input = Console.ReadLine().ToLower();
            switch(input)
            {
                case "1":
                    customerEamil.Type = CustomerData.CurrentCustomers;
                    break;
                case "2":
                    customerEamil.Type = CustomerData.OldCustomers;
                    break;
                case "3":
                    customerEamil.Type = CustomerData.NewCustomers;
                    break;
            }
        }


        private void DeleteCustomerData()
        {
            Console.Clear();
            ShowCustomerList();

            Console.WriteLine("What is the first name of the person you would like to delete?");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is the Last name of the peroson you would like to delete?");
            string lastName = Console.ReadLine();

            Console.WriteLine("What is the Email of the person you would like to delete?");
            string email = Console.ReadLine();

            Console.WriteLine("Enter the number for what type of Customer you would like to delete:\n" +
                                "1. Current Cust\n" +
                                "2. Old Customer\n" +
                                "3. New Customer\n");
            int customerData = ParseInput();


            CustomerData customer;
            switch (customerData)
            {
                default:
                case 1:
                    customer = CustomerData.CurrentCustomers;
                    break;
                case 2:
                    customer = CustomerData.OldCustomers;
                    break;

                case 3:
                    customer = CustomerData.NewCustomers;
                    break;
            }

            bool success = _emailRepo.RemoveCustomerBySpecifications(firstName, lastName, email);
            if(success == true)
            {
                Console.WriteLine($"Mr/Mrs {firstName }{ lastName} was successfully removed. ");
                Console.ReadLine();
                //Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Mr/Mrs {firstName}{lastName} was unable to be removed at thi time.");
                Console.ReadLine();
                Console.Clear();
                ShowCustomerList();
            }
        }

        private int ParseInput()
        {
            int input = int.Parse(Console.ReadLine());
            if (input < 1 || input > 3)
            {
                Console.WriteLine("Your input was not one os the choices provided, please select a valid number.");
                input = ParseInput();
            }
            return input;
        }
    }
}