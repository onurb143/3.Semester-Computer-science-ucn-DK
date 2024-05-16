using RESTfulService.DTOs;

namespace RESTfulService.BusinessLogicLayer
{

    public interface ICustomerdata
    {
        CustomerDto? Get(int id);
        List<CustomerDto>? Get(string? email);
        CustomerDto CreateNewCustomer(CustomerDto customerToAdd);
        CustomerDto Put(CustomerDto customerToUpdate);
        CustomerDto GetByUserId(string loginid);
        bool Delete(int id);

    }
}
