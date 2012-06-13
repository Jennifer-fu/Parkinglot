using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class Parkinglot
    {
        private readonly Dictionary<Ticket, Car> carList;

        public Parkinglot(int capacity)
        {
            Capacity = capacity;
            carList = new Dictionary<Ticket, Car>();
        }

        private int Capacity { get; set; }

        public Ticket Park(Car car)
        {
            if (Capacity == carList.Count)
                return null;
            var ticket = new Ticket();
            carList.Add(ticket, car);
            return ticket;
        }

        public Car PickUp(Ticket ticket)
        {
            if (!carList.ContainsKey(ticket))
                return null;
            var car = carList[ticket];
            carList.Remove(ticket);
            return car;
        }

        public static void Main(string[] args)
        {
        }

        public int AvailablePosition()
        {
            return Capacity - carList.Count;
        }

        public double AvailablePositionRate()
        {
            if (Capacity == 0) return 0;
            return Convert.ToDouble(AvailablePosition()) / Capacity;
        }
    }
}