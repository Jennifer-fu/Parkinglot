using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy : Parker
    {
        private readonly List<Parkinglot> parkinglots = new List<Parkinglot>();

        private readonly ParkinglotChooser chooser;

        public ParkingBoy(ParkinglotChooser chooser)
        {
            this.chooser = chooser;
        }

        public void Manage(Parkinglot parkinglot)
        {
            parkinglots.Add(parkinglot);
        }

        public Ticket Park(Car car)
        {
            var parkinglot = chooser.Choose(parkinglots);
            return parkinglot == null ? null : parkinglot.Park(car);
        }

        public Car PickUp(Ticket ticket)
        {
            return parkinglots.Select(parkinglot => parkinglot.PickUp(ticket)).FirstOrDefault(car => car != null);
        }

        public string Print(Reporter reporter)
        {
            reporter.Indent();
            var result = PrintContent(reporter);
            reporter.Outdent();
            return result;
        }

        private string PrintContent(Reporter reporter)
        {
            var report = new StringBuilder();
            report.AppendLine(String.Format("{0}parkingboy:", reporter.FormatString()));
            foreach (var parkinglot in parkinglots)
            {
                report.Append(parkinglot.Print(reporter));
            }
            return report.ToString();
        }
    }
}