using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    internal class AnyNotFull : ParkinglotChooser
    {
        public Parkinglot Choose(List<Parkinglot> parkinglots)
        {
            return parkinglots.FirstOrDefault(parkinglot => parkinglot.IsNotFull());
        }
    }
}