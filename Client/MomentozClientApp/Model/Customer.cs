namespace MomentozClientApp.Model
{
    // Customer-klassen repræsenterer oplysninger om en kunde i systemet.
    public class Customer
    {
        // Standardkonstruktør.
        public Customer() { }

        // Konstruktør til oprettelse af en ny kunde med angivelse af detaljer.
        public Customer(int customerID, string firstName, string lastName, string mobilePhone, string email, string loginUserId, string fullName)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            LoginUserId = loginUserId;
            FullName = fullName;
        }

        // Egenskab til at få eller indstille kundens ID.
        public int CustomerID { get; set; }

        // Egenskab til at få eller indstille kundens fornavn.
        public string FirstName { get; set; }

        // Egenskab til at få eller indstille kundens efternavn.
        public string LastName { get; set; }

        // Egenskab til at få eller indstille kundens mobiltelefonnummer.
        public string MobilePhone { get; set; }

        // Egenskab til at få eller indstille kundens e-mailadresse.
        public string Email { get; set; }

        // Egenskab til at få eller indstille kundens login-brugerID.
        public string LoginUserId { get; set; }

        // Egenskab til at få eller indstille kundens fulde navn.
        public string FullName { get; set; }
    }
}
