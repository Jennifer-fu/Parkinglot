using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy : Parker
    {
        internal readonly List<Parkinglot> parkinglots = new List<Parkinglot>();

        private ParkinglotChooser chooser;

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

        public string Print(int depth)
        {
            var report = new StringBuilder();
            string tabString = "";
            for (int i = 0; i < depth; i++)
            {
                tabString += "\t";
            }
         
            report.AppendLine(String.Format("{0}parkingboy:",tabString));
            foreach (var parkinglot in parkinglots)
            {
                report.Append(parkinglot.Print(depth+1));
            }
            return report.ToString();
        }
    }
}