using DatabaseData.ModelLayer;
using DatabaseData.DatabaseLayer;
using RESTfulService.DTOs;
using RESTfulService.BusinessLogicLayer;

namespace RESTfulService.BusinesslogicLayer
{

    public class CustomerdataControl : ICustomerdata
    {
        private readonly ICustomerAccess _customerAccess;

        public CustomerdataControl(ICustomerAccess inCustomerAccess) { 
            _customerAccess = inCustomerAccess;
           
        }
        public CustomerDto? Get(int idToMatch)
        {
            CustomerDto? foundCustomerDto;
            try
            {
                Customer? foundCustomer = _customerAccess.GetCustomerById(idToMatch);
                foundCustomerDto = ModelConversion.CustomerDtoConvert.FromCustomer(foundCustomer);
            }
            catch
            {
                foundCustomerDto = null;
            }
            return foundCustomerDto;
        }

        public List<CustomerDto>? Get(string? email)
        {
            List<CustomerDto>? foundDtos;
            try
            {
                List<Customer>? foundCustomers;
                if (email == null)
                {
                 foundCustomers = _customerAccess.GetCustomerAll();
                } else
                {
                  Customer c = _customerAccess.GetByEmail(email);
                    foundCustomers = new List<Customer>();
                    foundCustomers.Add(c);
                }
                foundDtos = ModelConversion.CustomerDtoConvert.FromCustomerCollection(foundCustomers);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }
        public CustomerDto? CreateNewCustomer(CustomerDto customerToAdd)
        {
            CustomerDto? createdCustomer = null;
            try
            {
                Customer? dbCustomer = ModelConversion.CustomerDtoConvert.ToCustomer(customerToAdd);
                if (dbCustomer is not null)
                {
                    Customer createdDbCustomer = _customerAccess.CreateCustomerMinimal(dbCustomer);
                    createdCustomer = ModelConversion.CustomerDtoConvert.FromCustomer(dbCustomer);
                }
            }
            catch
            {

                createdCustomer = null;
            }
            return createdCustomer;
        }


        public CustomerDto Put(CustomerDto customerToUpdate)
        {
            CustomerDto? createdCustomer = null;
            try
            {
                Customer? dbCustomer = ModelConversion.CustomerDtoConvert.ToCustomer(customerToUpdate);
                if (dbCustomer is not null)
                {
                    Customer createdDbCustomer = _customerAccess.UpdateCustomer(dbCustomer);
                    createdCustomer = ModelConversion.CustomerDtoConvert.FromCustomer(dbCustomer);
                }
            }
            catch
            {

                createdCustomer = null;
            }
            return createdCustomer;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerDto? GetByUserId(string loginUserId)
        {
            CustomerDto? foundCustomerDto = null;
            try
            {
                Customer? foundCustomer = _customerAccess.GetCustomerByUserId(loginUserId);
                if (foundCustomer != null)
                {
                    foundCustomerDto = ModelConversion.CustomerDtoConvert.FromCustomer(foundCustomer);
                }
            }
            catch
            {
                foundCustomerDto = null;
            }
            return foundCustomerDto;
        }
    }
}
