using DatabaseData.ModelLayer;


namespace DatabaseData.DatabaseLayer
{
    public interface IFlightAccess
    {
        Flight GetFlightById(int id);
        List<Flight> GetFlightAll();
        Flight CreateFlight(Flight flightToAdd);
        bool DeleteFlightById(int id);
    }
}
