using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class Manager : Parker
    {
        private List<Parker> parkers = new List<Parker>();

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

        public string Print(Reporter reporter)
        {
            var report = new StringBuilder();
            report.Append(reporter.Indent());
            report.Append("manager:");
            report.AppendLine();
            foreach (var parker in GetParkers())
            {
                report.Append(parker.Print(new Reporter(reporter.IndentNumber + 1)));
            }
            return report.ToString();
        }

        public List<Parker> GetParkers()
        {
            return parkers;
        }
    }
}