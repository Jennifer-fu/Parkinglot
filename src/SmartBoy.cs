using System.Linq;

namespace ParkingLot
{
    public class SmartBoy : ParkingBoy
    {
        protected Parkinglot FindParkinglot()
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