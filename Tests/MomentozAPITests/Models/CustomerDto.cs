using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozAPITests.Models
{
    public class CustomerDto
    {
        public CustomerDto(int inCustomerID, string? inFirstName, string? lastName, string? mobilePhone, string email, string? streetName, string? zipCode, string? loginUserId)
        {
            CustomerID = inCustomerID;
            FirstName = inFirstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            StreetName = streetName;
            ZipCode = zipCode;
            LoginUserId = loginUserId;
        }
        public CustomerDto() { }
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string Email { get; set; }
        public string? StreetName { get; set; }
        public string? ZipCode { get; set; }
        public string? LoginUserId { get; set; }


        public string? Fullname
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
