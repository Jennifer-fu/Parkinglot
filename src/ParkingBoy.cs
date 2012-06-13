using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        internal readonly List<Parkinglot> parkinglots = new List<Parkinglot>();
        
        public void Manage(Parkinglot parkinglot)
        {
            parkinglots.Add(parkinglot);
        }

        public Ticket Park(Car car)
        {
            var parkinglot = FindParkinglot();
            return parkinglot==null?null:parkinglot.Park(car);
        }

        private Parkinglot FindParkinglot()
        {
            Parkinglot choosedParkinglot = null;
            foreach (var parkinglot in parkinglots)
            {
                if (parkinglot.IsNotFull()) choosedParkinglot = parkinglot;
            }
            return choosedParkinglot;
        }

        public Car PickUp(Ticket ticket)
        {
            return parkinglots.Select(parkinglot => parkinglot.PickUp(ticket)).FirstOrDefault(car => car != null);
        }
    }
}