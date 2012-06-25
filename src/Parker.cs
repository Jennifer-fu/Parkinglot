namespace ParkingLot
{
    public interface Parker
    {
        Ticket Park(Car car);
        Car PickUp(Ticket ticket);
        string Print(int depth);
    }
}