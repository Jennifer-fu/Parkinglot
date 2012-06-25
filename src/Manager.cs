using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class Manager : Parker
    {
        private readonly List<Parker> parkers = new List<Parker>();

        public Ticket Park(Car car)
        {
            return parkers.Select(parker => parker.Park(car)).FirstOrDefault(ticket => ticket != null);
        }

        public Car PickUp(Ticket ticket)
        {
            return parkers.Select(parker => parker.PickUp(ticket)).FirstOrDefault(car => car != null);
        }

        public void Manage(Parker parker)
        {
            parkers.Add(parker);
        }

        public string Print(int depth)
        {
            var report = new StringBuilder();
            string tabString = "";
            for (int i = 0; i < depth; i++)
            {
                tabString += "\t";
            }
         
            report.AppendLine(String.Format("{0}manager:",tabString));
            
            foreach (var parker in parkers)
            {
                report.Append(parker.Print(depth+1));
            }
            return report.ToString();
        }
    }
}