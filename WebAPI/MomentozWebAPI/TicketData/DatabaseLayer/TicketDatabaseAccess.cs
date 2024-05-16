using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TicketData.ModelLayer;

namespace TicketData.DatabaseLayer
{
    public class TicketDatabaseAccess : ITicketAccess
    {
        readonly string? _connectionString;

        public TicketDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MomentozConnection");
        }

        public TicketDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateTicket(Ticket aTicket)
        {
            int insertedId = -1;
            string insertString = @"insert into Ticket(firstName, lastName, mobilePhone, email) 
                                    OUTPUT INSERTED.ID 
                                    values(@FirstNam, @LastNam, @MobilePhon, @Emai)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                CreateCommand.Parameters.Add(new SqlParameter("@FirstNam", aTicket.FirstName));
                CreateCommand.Parameters.Add(new SqlParameter("@LastNam", aTicket.LastName));
                CreateCommand.Parameters.Add(new SqlParameter("@MobilePhon", aTicket.MobilePhone));
                CreateCommand.Parameters.Add(new SqlParameter("@Emai", aTicket.Email));

                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }

        public bool DeleteTicketById(int id)
        {
            throw new NotImplementedException();
        }

        // Other methods like DeleteTicketById, UpdateTicket would be here.

        public List<Ticket> GetTicketAll()
        {
            List<Ticket> foundTickets = new List<Ticket>();
            string queryString = "select id, firstName, lastName, mobilePhone, email from Ticket";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader ticketReader = readCommand.ExecuteReader();
                while (ticketReader.Read())
                {
                    foundTickets.Add(GetTicketFromReader(ticketReader));
                }
            }
            return foundTickets;
        }

        public Ticket GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTicket(Ticket ticketToUpdate)
        {
            throw new NotImplementedException();
        }

        private Ticket GetTicketFromReader(SqlDataReader ticketReader)
        {
            int tempId = ticketReader.GetInt32(ticketReader.GetOrdinal("id"));
            string tempFirstName = ticketReader.GetString(ticketReader.GetOrdinal("firstName"));
            string tempLastName = ticketReader.GetString(ticketReader.GetOrdinal("lastName"));
            bool isNotNull = !ticketReader.IsDBNull(ticketReader.GetOrdinal("mobilePhone"));
            string? tempMobilePhone = isNotNull ? ticketReader.GetString(ticketReader.GetOrdinal("mobilePhone")) : null;
            string? tempEmail = ticketReader.IsDBNull(ticketReader.GetOrdinal("email")) ? null : ticketReader.GetString(ticketReader.GetOrdinal("email"));

            return new Ticket(tempId, tempFirstName, tempLastName, tempMobilePhone, tempEmail);
        }

        // The method GetTicketById would be here, similar to GetTicketAll, but with parameterized SQL for a single ID.

    }
}
