using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class MaxAvailableRate:ParkinglotChooser
    {
        public Parkinglot Choose(List<Parkinglot> parkinglots)
        {
            double maxAvailableRate = 0;
            Parkinglot maxParkingLot = null;
            foreach (Parkinglot parkinglot in parkinglots.Where(parkinglot => parkinglot.AvailablePositionRate() > maxAvailableRate))
            {
                maxAvailableRate = parkinglot.AvailablePositionRate();
                maxParkingLot = parkinglot;
            }
            return maxParkingLot;

        }
    }
}