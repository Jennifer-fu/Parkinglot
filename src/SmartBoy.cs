using System.Linq;

namespace ParkingLot
{
    public class SmartBoy : ParkingBoy
    {
        public Ticket Park(Car car)
        {
            int maxAvailablePosition = 0;
            Parkinglot maxParkinglot = null;
            foreach (Parkinglot parkinglot in parkinglots.Where(parkinglot => parkinglot.AvailablePosition() > maxAvailablePosition))
            {
                maxAvailablePosition = parkinglot.AvailablePosition();
                maxParkinglot = parkinglot;
            }
            return maxParkinglot != null ? maxParkinglot.Park(car) : null;
        }
    }
}