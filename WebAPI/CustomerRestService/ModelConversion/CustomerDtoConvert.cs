using DatabaseData.ModelLayer;
using RESTfulService.DTOs;

namespace RESTfulService.ModelConversion
{
    public class CustomerDtoConvert
    {
        public static List<CustomerDto> FromCustomerCollection(List<Customer> inCustomers)
        {
            if (inCustomers == null)
                return null;

            var aCustomerReadDtoList = new List<CustomerDto>();
            foreach (Customer aCustomer in inCustomers)
            {
                if (aCustomer != null)
                {
                    var tempDto = FromCustomer(aCustomer);
                    aCustomerReadDtoList.Add(tempDto);
                }
            }
            return aCustomerReadDtoList;
        }

        public static CustomerDto FromCustomer(Customer inCustomer)
        {
            if (inCustomer == null)
                return null;

            return new CustomerDto(inCustomer.CustomerID, inCustomer.FirstName, inCustomer.LastName, inCustomer.MobilePhone, inCustomer.Email, inCustomer.StreetName, inCustomer.ZipCode, inCustomer.LoginUserId);
        }

        public static Customer ToCustomer(CustomerDto inDto)
        {
            if (inDto == null)
                return null;

            return new Customer(inDto.CustomerID, inDto.FirstName, inDto.LastName, inDto.MobilePhone, inDto.Email, inDto.StreetName, inDto.ZipCode, inDto.LoginUserId?.ToString()); // Konverter LoginUserId til en streng
        }
    }
}
