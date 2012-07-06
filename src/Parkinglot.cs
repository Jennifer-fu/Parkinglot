using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class Parkinglot : Parker
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
            if (!IsNotFull()) return null;
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

        public int AvailablePosition()
        {
            return Capacity - carList.Count;
        }

        public double AvailablePositionRate()
        {
            if (Capacity == 0) return 0;
            return Convert.ToDouble(AvailablePosition())/Capacity;
        }

        public bool IsNotFull()
        {
            return AvailablePosition() > 0;
        }

        public static void Main(string[] args)
        {
        }

        public string Print(Reporter reporter)
        {
            return reporter.Print(this);
        }
    }
}