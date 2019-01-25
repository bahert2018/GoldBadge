using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _05_Challenge
{
    public enum CustomerData { CurrentCustomers, OldCustomers, NewCustomers }
    public class EmailProgram
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerData Type { get; set; }
        public string Email { get; set; }

        public EmailProgram(CustomerData customerData, string firstName, string lastName, string email)
        {
            Type = customerData;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public EmailProgram()
        {

        }
    }
}
