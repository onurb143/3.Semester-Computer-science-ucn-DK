namespace DatabaseData.ModelLayer
{
    public class Customer
    {
        public Customer() { }

        // Konstruktør uden CustomerID.
        // Bruges til oprettelse af en ny kunde uden angivelse af ID.
        public Customer(string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            StreetName = streetName;
            ZipCode = zipCode;
        }

        // Konstruktør med CustomerID og LoginUserId.
        // Bruger den tidligere definerede konstruktør til at initialisere de grundlæggende egenskaber.
        // - loginUserId: Unik identifikator for brugeren, der er tilknyttet kunden.
        //public Customer(string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode, string loginUserId)
        //    : this(firstName, lastName, mobilePhone, email, streetName, zipCode)
        //{
        //    LoginUserId = loginUserId;
        //}

        // Konstruktør med CustomerID, LoginUserId og alle de grundlæggende egenskaber.
        // Bruger den tidligere definerede konstruktør til at initialisere de grundlæggende egenskaber.
        // - customerID: Unik identifikator for kunden.
        // - loginUserId: Unik identifikator for brugeren, der er tilknyttet kunden.
        public Customer(int customerID, string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode, string loginUserId)
            : this(firstName, lastName, mobilePhone, email, streetName, zipCode)
        {
            CustomerID = customerID;
            LoginUserId = loginUserId;
        }

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string? ZipCode { get; set; }
        public string? StreetName { get; set; }
        public string LoginUserId { get; set; }

        // Egenskab der bruger string concatenation til at danne det fulde navn (Fornavn Efternavn) for kunden.
        public string? Fullname
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

    }
}
