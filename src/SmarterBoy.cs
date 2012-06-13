using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.src
{
    public class SmarterBoy : ParkingBoy
    {
        protected Parkinglot FindParkinglot()
        {
            double maxAvailableRate = 0;
            Parkinglot maxParkingLot = null;
            foreach (var parkinglot in parkinglots.Where(parkinglot => parkinglot.AvailablePositionRate() > maxAvailableRate))
            {
                maxAvailableRate = parkinglot.AvailablePositionRate();
                maxParkingLot = parkinglot;
            }
            return maxParkingLot;
        }
    }
}