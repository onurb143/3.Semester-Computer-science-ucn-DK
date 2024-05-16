namespace MomentozClientApp.DTOs
{
    public class CustomerDto
    {

        public CustomerDto() { }

        public CustomerDto(string? inFirstName, string? inLastName, string? inMobilePhone, string? email)
        {
            FirstName = inFirstName;
            LastName = inLastName;
            MobilePhone = inMobilePhone;
            Email = email;
        }

        public CustomerDto(string? inFirstName, string? inLastName, string? inMobilePhone, string? email, string? loginUserId)
        {
            FirstName = inFirstName;
            LastName = inLastName;
            MobilePhone = inMobilePhone;
            Email = email;
            LoginUserId = loginUserId;
        }



        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }

        public string? Email { get; set; }

        public string? LoginUserId { get; set; }
        public string? FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}

