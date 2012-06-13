using System.Collections.Generic;

namespace ParkingLot.src
{
    public interface ParkinglotChooser
    {
        Parkinglot Choose(List<Parkinglot> parkinglots);
    }
}