using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class Manager : Parker
    {
        internal readonly List<Parker> parkers = new List<Parker>();

        public Ticket Park(Car car)
        {
            return parkers.Select(parker => parker.Park(car)).FirstOrDefault(ticket => ticket != null);
        }

        public Car PickUp(Ticket ticket)
        {
            return parkers.Select(parker => parker.PickUp(ticket)).FirstOrDefault(car => car != null);
        }

        public void Manage(Parker parker)
        {
            parkers.Add(parker);
        }

        public string Print(Reporter reporter)
        {
            return reporter.PrintParkingManager(this);
        }
    }
}