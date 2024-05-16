using MomentozClientApp.Model;  // Bruger Customer-klassen fra MomentozClientApp.Model namespace.
using MomentozClientApp.Servicelayer;  // Bruger ICustomerAccess-grænsefladen fra MomentozClientApp.Servicelayer namespace.

namespace MomentozClientApp.BusinessLogicLayer
{
    // CustomerDataControl-klassen implementerer ICustomerdata-grænsefladen og styrer adgangen til kundedata.
    public class CustomerDataControl : ICustomerdata
    {
        private readonly ICustomerAccess _customerAccess;

        // Konstruktør, der modtager en ICustomerAccess-implementering som parameter.
        public CustomerDataControl(ICustomerAccess inCustomerAccess)
        {
            _customerAccess = inCustomerAccess;
        }

        // Metode til at hente en kunde efter e-mail.
        public Customer? Get(string email)
        {
            try
            {
                return _customerAccess.GetCustomerByEmail(email).Result;
            }
            catch
            {
                return null;
            }
        }

        // Metode til at hente alle kunder som en liste.
        public List<Customer>? Get()
        {
            try
            {
                return _customerAccess.GetCustomerAll().Result;
            }
            catch
            {
                return null;
            }
        }

        // Metode til at tilføje en ny kunde.
        public int Add(Customer customerToAdd)
        {
            try
            {
                if (customerToAdd != null)
                {
                    return _customerAccess.CreateCustomer(customerToAdd).Result;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        // Metode til at opdatere en eksisterende kunde (endnu ikke implementeret).
        public bool Put(Customer customerToUpdate)
        {
            throw new NotImplementedException();
        }

        // Metode til at slette en kunde efter ID (endnu ikke implementeret).
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        // Metode til at hente en kunde efter login-brugerID ved direkte kald til _customerAccess.
        public Customer? GetByUserId(string loginUserId)
        {
            try
            {
                return _customerAccess.GetCustomerByUserId(loginUserId).Result;
            }
            catch
            {
                return null;
            }
        }
    }
}
