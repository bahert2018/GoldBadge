using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge
{
    public class EmailProgramRepository
    {
        List<EmailProgram> _emails = new List<EmailProgram>();

        public void AddEmailProgramToList(EmailProgram addCustomerEmail)
        {
            _emails.Add(addCustomerEmail);
        }

        public List<EmailProgram> GetEmailProgram()
        {
            return _emails;
        }

        public void RemoveCustomerEmail(EmailProgram Customer)
        {
            _emails.Remove(Customer);
        }


        public bool RemoveCustomerBySpecifications(string firstName, string lastName, string email)
        {
            bool successful = false;
            foreach (EmailProgram Customer in _emails)
            {
                if 
                    (Customer.FirstName == firstName && Customer.LastName == lastName && Customer.Email == email)
                {
                    RemoveCustomerEmail(Customer);
                    successful = true;
                    break;
                }
            }
            return successful;
        }

        public EmailProgram GetEmailProgram(string firstName, string lastName)
        {
            EmailProgram UpdateInfo = new EmailProgram();
            foreach (EmailProgram email in _emails)
            {
                if(email.FirstName == firstName && email.LastName == lastName)
                {
                    UpdateInfo = email;
                }
            }
            return UpdateInfo;
        }
    }
}
