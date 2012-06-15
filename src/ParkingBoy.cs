using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy : Parker
    {
        internal readonly List<Parkinglot> parkinglots = new List<Parkinglot>();

        private ParkinglotChooser chooser;

        public ParkingBoy(ParkinglotChooser chooser)
        {
            this.chooser = chooser;
        }

        public void Manage(Parkinglot parkinglot)
        {
            parkinglots.Add(parkinglot);
        }

        public Ticket Park(Car car)
        {
            var parkinglot = chooser.Choose(parkinglots);
            return parkinglot == null ? null : parkinglot.Park(car);
        }

        public Car PickUp(Ticket ticket)
        {
            return parkinglots.Select(parkinglot => parkinglot.PickUp(ticket)).FirstOrDefault(car => car != null);
        }
    }
}