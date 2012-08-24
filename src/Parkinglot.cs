using System;
using System.Collections.Generic;
using System.Text;

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
            if (!IsNotFull()) throw new ParkinglotFullException();
            var ticket = new Ticket();
            carList.Add(ticket, car);
            return ticket;
        }

        public Car PickUp(Ticket ticket)
        {
            if (!carList.ContainsKey(ticket))
                throw new WrongTicketException();
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
            reporter.Indent();
            var report = new StringBuilder();
            report.AppendLine(String.Format("{0}parkinglot: {1}", reporter.FormatString(), AvailablePosition()));
            reporter.Outdent();
            return report.ToString();
        }
    }
}