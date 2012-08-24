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
            reporter.Indent();
            var result = PrintContent(reporter);
            reporter.Outdent();
            return result;
        }

        private string PrintContent(Reporter reporter)
        {
            var report = new StringBuilder();
            report.AppendLine(string.Format("{0}manager:", reporter.FormatString()));
            foreach (var parker in parkers)
            {
                report.Append(parker.Print(reporter));
            }
            return report.ToString();
        }
    }
}