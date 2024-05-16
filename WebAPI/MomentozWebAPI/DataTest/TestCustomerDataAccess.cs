using Xunit;
using Microsoft.Data.SqlClient;
using System;

namespace DataTest
{
    public class DatabaseConnectionTest
    {
        [Fact]
        public void CanConnectToDatabase()
        {
            var connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S224_10461225; User Id=DMA-CSD-S224_10461225; Password=Password1!; Encrypt=False;";
            var exception = Record.Exception(() =>
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
            });

            Assert.IsNull(exception);
        }
    }
}
