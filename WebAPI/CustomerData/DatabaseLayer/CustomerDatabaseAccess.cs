using Microsoft.Extensions.Configuration;
using DatabaseData.ModelLayer;
using Microsoft.Data.SqlClient;

namespace DatabaseData.DatabaseLayer
{
    public class CustomerDatabaseAccess : ICustomerAccess
    {
        readonly string? _connectionString;


        public CustomerDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MomentozConnection");
        }

        public CustomerDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }


        public int CreateCustomer(Customer aCustomer)
        {
            int insertedId = -1;
            string insertString = @" INSERT INTO Customers (FirstName, LastName, MobilePhone, email, streetName, StreetName) OUTPUT INSERTED.ID 
                                    VALUES (@FirstName, @LastName, @MobilePhone, @Email, @StreetName, @Zipcode)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                if (string.IsNullOrWhiteSpace(aCustomer.FirstName) || string.IsNullOrWhiteSpace(aCustomer.LastName))
                {
                    throw new ArgumentException("Fornavn og efternavn er påkrævet.");
                }

                CreateCommand.Parameters.Add(new SqlParameter("@FirstName", aCustomer.FirstName));
                CreateCommand.Parameters.Add(new SqlParameter("@LastName", aCustomer.LastName));
                CreateCommand.Parameters.Add(new SqlParameter("@MobilePhone", aCustomer.MobilePhone));
                CreateCommand.Parameters.Add(new SqlParameter("@Email", aCustomer.Email));
                CreateCommand.Parameters.Add(new SqlParameter("@StreetName", aCustomer.StreetName));
                CreateCommand.Parameters.Add(new SqlParameter("@Zipcode", aCustomer.ZipCode));

                con.Open();

                insertedId = (int)CreateCommand.ExecuteScalar();
              
            }
            return insertedId;
        }


        public bool DeleteCustomerById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Customer> GetCustomerAll()
        {
            List<Customer> foundCustomers;
            Customer readCustomer;
            
            string queryString = "SELECT CustomerID, FirstName, LastName, MobilePhone, Email, StreetName, Zipcode, loginUserId FROM Customers";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
            
                SqlDataReader customerReader = readCommand.ExecuteReader();
              
                foundCustomers = new List<Customer>();
                while (customerReader.Read())
                {
                    readCustomer = GetCustomerFromReader(customerReader);
                    foundCustomers.Add(readCustomer);
                }
            }
            return foundCustomers;
        }

        private Customer GetCustomerFromReader(SqlDataReader customerReader)
        {
            Customer foundCustomer;
            int tempCustomerID;
            bool isNotNull; 
            string? tempFirstName, tempLastName, tempMobilePhone, tempEmail, tempStreetName, tempLoginUserId, tempZipCode;

         
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("customerID"));
            tempCustomerID = isNotNull ? customerReader.GetInt32(customerReader.GetOrdinal("customerID")) : 0;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("firstName"));
            tempFirstName = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("firstName")) : null;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("lastName"));
            tempLastName = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("lastName")) : null;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("mobilePhone"));
            tempMobilePhone = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("mobilePhone")) : null;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("email"));
            tempEmail = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("email")) : null;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("streetName"));
            tempStreetName = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("streetName")) : null;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("zipcode"));
            tempZipCode = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("zipcode")) : null;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("loginUserId"));
            tempLoginUserId = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("loginUserId")) : null;

            // Create object    
            foundCustomer = new Customer(tempCustomerID, tempFirstName, tempLastName, tempMobilePhone, tempEmail, tempStreetName, tempZipCode, tempLoginUserId);
            return foundCustomer;
        }

        public Customer GetCustomerById(int findId)
        {
            Customer foundCustomer;
            //
            string queryString = "SELECT customerID, firstName, lastName, mobilePhone, email, streetname, zipcode, LoginUserId loginuserid FROM Customers WHERE id = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                // Prepace SQL
                SqlParameter idParam = new SqlParameter("@Id", findId);
                readCommand.Parameters.Add(idParam);
                //
                con.Open();
                // Execute read
                SqlDataReader customerReader = readCommand.ExecuteReader();
                foundCustomer = new Customer();
                while (customerReader.Read())
                {
                    foundCustomer = GetCustomerFromReader(customerReader);
                }
            }
            return foundCustomer;
        }


        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            Customer updatedCustomer = null;
            
            try
            {
                string setVariables = "SET FirstName = @fName, LastName = @lName, MobilePhone = @phone, StreetName = @street, ZipCode = @zip";
                string condition = "WHERE loginUserId = @UserId";

                string queryString = "UPDATE Customers " + setVariables + " " + condition;

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand updateCommand = new SqlCommand(queryString, con))
                {
                    // Prepare SQL
                    SqlParameter cidParam = new SqlParameter("@UserId", customerToUpdate.LoginUserId);
                    SqlParameter fnameParam = new SqlParameter("@fName", customerToUpdate.FirstName);
                    SqlParameter lnameParam = new SqlParameter("@lName", customerToUpdate.LastName);
                    SqlParameter phoneParam = new SqlParameter("@phone", customerToUpdate.MobilePhone);
                    SqlParameter streetParam = new SqlParameter("@street", customerToUpdate.StreetName);
                    SqlParameter zipCodeParam = new SqlParameter("@zip", customerToUpdate.ZipCode);

                    updateCommand.Parameters.Add(cidParam);
                    updateCommand.Parameters.Add(fnameParam);
                    updateCommand.Parameters.Add(lnameParam);
                    updateCommand.Parameters.Add(phoneParam);
                    updateCommand.Parameters.Add(streetParam);
                    updateCommand.Parameters.Add(zipCodeParam);

                    con.Open();

                    // Execute update
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        updatedCustomer = GetCustomerByUserId(customerToUpdate.LoginUserId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return updatedCustomer;
        }

        public Customer GetCustomerByUserId(string? findUserId)
        {
            Customer foundCustomer = null;

            try
            {
                string queryString = "SELECT CustomerID, FirstName, LastName, Email, MobilePhone, StreetName, ZipCode, loginUserId FROM Customers WHERE loginUserId = @UserId";

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand readCommand = new SqlCommand(queryString, con))
                {
                    // Prepare SQL
                    SqlParameter idParam = new SqlParameter("@UserId", findUserId);
                    readCommand.Parameters.Add(idParam);

                    con.Open();

                    // Execute read
                    SqlDataReader customerReader = readCommand.ExecuteReader();

                    while (customerReader.Read())
                    {
                        foundCustomer = GetCustomerFromReader(customerReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return foundCustomer;
        }

        public Customer CreateCustomerMinimal(Customer aMinimalCustomer)
        {
            Customer createdCustomer;
            
            string insertString = "insert into Customers(loginUserId, email) values(@loginUserI, @emai)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter fNameParam = new("@loginUserI", aMinimalCustomer.LoginUserId);
                CreateCommand.Parameters.Add(fNameParam);
                SqlParameter lNameParam = new("@emai", aMinimalCustomer.Email);
                CreateCommand.Parameters.Add(lNameParam);
                
                con.Open();
               
                CreateCommand.ExecuteNonQuery();
               
                createdCustomer = GetCustomerByUserId(aMinimalCustomer.LoginUserId);
            }
            return createdCustomer;
        }

        public Customer? GetByEmail(string findEmail)
        {
            Customer foundCustomer;

            string queryString = "SELECT CustomerID, FirstName, LastName, Email, MobilePhone, StreetName, ZipCode, loginUserId FROM Customers WHERE email = @email";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@email", findEmail);
                readCommand.Parameters.Add(idParam);
                
                con.Open();
              
                SqlDataReader customerReader = readCommand.ExecuteReader();
                foundCustomer = new Customer();
                while (customerReader.Read())
                {
                    foundCustomer = GetCustomerFromReader(customerReader);
                }
            }
            return foundCustomer;
        }
    }



}
