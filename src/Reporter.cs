using System;
using System.Text;

namespace ParkingLot
{
    public class Reporter
    {
        private int depth;

        public Reporter(int depth)
        {
            this.depth = depth;
        }

        public string PrintParkinglot(Parkinglot parkinglot)
        {
            return String.Format("{0}parkinglot: {1}\r\n", TabString(depth), parkinglot.AvailablePosition());
        }

        public string PrintParkingBoy(ParkingBoy parkingBoy)
        {
            var report = new StringBuilder();
            report.AppendLine(String.Format("{0}parkingboy:", TabString(depth)));

            foreach (var parkinglot in parkingBoy.parkinglots)
            {
                report.Append(parkinglot.Print(new Reporter(depth + 1)));
            }
            return report.ToString();
        }

        public string PrintParkingManager(Manager manager)
        {
            var report = new StringBuilder();
            report.AppendLine(String.Format("{0}manager:", TabString(depth)));

            foreach (var parker in manager.parkers)
            {
                report.Append(parker.Print(new Reporter(depth + 1)));
            }
            return report.ToString();
        }

        private string TabString(int depth)
        {
            string tabString = "";
            for (int i = 0; i < depth; i++)
            {
                tabString += "\t";
            }
            return tabString;
        }
    }
}