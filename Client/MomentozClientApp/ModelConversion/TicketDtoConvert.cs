using MomentozClientApp.DTOs;
using MomentozClientApp.ModelLayer;
namespace MomentozClientApp.ModelConversion
{
    public class TicketDtoConvert
    {
        public static List<TicketDto> FromTicketCollection(List<Ticket> inTickets)
        {
            var aTicketReadDtoList = new List<TicketDto>();
            foreach (Ticket aTicket in inTickets)
            {
                var tempDto = FromTicket(aTicket);
                aTicketReadDtoList.Add(tempDto);
            }
            return aTicketReadDtoList;
        }
        public static TicketDto FromTicket(Ticket inTicket)
        {
            return new TicketDto
            {
                Id = inTicket.Id,
                Type = inTicket.Type,
                TicketNumber = inTicket.TicketNumber,
                BaggageID = inTicket.BaggageID,
                FlightID = inTicket.FlightID
            };
        }
        public static Ticket ToTicket(TicketDto inDto)
        {
            return new Ticket(inDto.Id, inDto.Type, inDto.TicketNumber, inDto.BaggageID, inDto.FlightID);
        }
    }
}