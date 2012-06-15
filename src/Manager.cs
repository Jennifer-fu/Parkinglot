using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class Manager
    {
        List<Parker> parkers = new List<Parker>();

        public void Manage(Parker parker)
        {
            parkers.Add(parker);   
        }

        public Ticket Park(Car car)
        {
            return parkers.Select(parker => parker.Park(car)).FirstOrDefault(ticket => ticket != null);
        }

        public Car PickUp(Ticket ticket)
        {
            return parkers.Select(parker => parker.PickUp(ticket)).FirstOrDefault(car => car != null);
        }
    }
}