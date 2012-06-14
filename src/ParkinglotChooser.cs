using System.Collections.Generic;

namespace ParkingLot
{
    public interface ParkinglotChooser
    {
        Parkinglot Choose(List<Parkinglot> parkinglots);
    }
}