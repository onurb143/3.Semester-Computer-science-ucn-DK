namespace TicketData.ModelLayer
{
    public class Ticket
    {
        public Ticket(string? firstName)
        {
        }

        public Ticket(string? firstName, string? lastName, string? mobilePhone, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
        }

        public Ticket(int id, string? firstName, string? lastName, string? mobilePhone, string? email)
            : this(firstName, lastName, mobilePhone, email)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }

        public bool IsTicketEmpty
        {
            get
            {
                return String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName);
            }
        }
    }
}
