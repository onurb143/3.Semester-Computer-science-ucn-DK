namespace RESTfulService.DTOs
{
    public class CustomerDto
    {

        //public CustomerDto(string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    MobilePhone = mobilePhone;
        //    Email = email;
        //    StreetName = streetName;
        //    ZipCode = zipCode;
        //}
        //public CustomerDto(int customerID, string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode)
        //{
        //    CustomerID = customerID;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    MobilePhone = mobilePhone;
        //    Email = email;
        //    StreetName = streetName;
        //    ZipCode = zipCode;
        //}
        //public CustomerDto(int customerID, string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode, string? loginUserId)
        //{
        //    CustomerID = customerID;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    MobilePhone = mobilePhone;
        //    Email = email;
        //    StreetName = streetName;
        //    ZipCode = zipCode;
        //    LoginUserId = loginUserId;
        //}

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
