using MomentozClientApp.Model;  // Bruger Order-klassen fra MomentozClientApp.Model namespace.
using MomentozClientApp.ServiceLayer;  // Bruger IOrderAccess-grænsefladen fra MomentozClientApp.ServiceLayer namespace.

namespace MomentozClientApp.BusinessLogicLayer
{
    // OrderData-klassen er ansvarlig for forretningslogikken relateret til ordredata.
    public class OrderData : IOrderdata
    {
        private readonly IOrderAccess _orderAccess;

        // Konstruktør, der modtager en IOrderAccess-implementering som parameter.
        public OrderData(IOrderAccess orderAccess)
        {
            _orderAccess = orderAccess;
        }

        // Metode til at hente en ordre efter ID (endnu ikke implementeret).
        public Order? Get(int id)
        {
            throw new NotImplementedException();
        }

        // Metode til at hente alle ordrer (endnu ikke implementeret).
        public List<Order>? Get()
        {
            throw new NotImplementedException();
        }

        // Metode til at tilføje en ny ordre.
        public int Add(Order orderToAdd)
        {
            try
            {
                if (orderToAdd != null)
                {
                    int insertedId = -1; /* Dine databaseindsætningsoperationer her */
                    return insertedId;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return -1;  // Returnerer -1 i tilfælde af en fejl.
            }
        }

        // Metode til at opdatere en eksisterende ordre (endnu ikke implementeret).
        public bool Put(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }

        // Metode til at slette en ordre efter ID (endnu ikke implementeret).
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
