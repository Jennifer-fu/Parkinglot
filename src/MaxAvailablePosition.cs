using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.src
{
    public class MaxAvailablePosition:ParkinglotChooser
    {
        public Parkinglot Choose(List<Parkinglot> parkinglots)
        {
            int maxAvailablePosition = 0;
            Parkinglot maxParkinglot = null;
            foreach (
                Parkinglot parkinglot in parkinglots.Where(parkinglot => parkinglot.AvailablePosition() > maxAvailablePosition))
            {
                maxAvailablePosition = parkinglot.AvailablePosition();
                maxParkinglot = parkinglot;
            }
            return maxParkinglot;
        }
    }
}