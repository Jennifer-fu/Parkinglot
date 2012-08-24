using System;
using System.Text;

namespace ParkingLot
{
    public class Reporter
    {
        private int indentNumber;

        public Reporter(int indentNumber)
        {
            this.indentNumber = indentNumber;
        }

        public string Print(Parkinglot parkinglot)
        {
            return String.Format("{0}parkinglot: {1}\r\n", IndentString(), parkinglot.AvailablePosition());
        }

        public string Print(ParkingBoy parkingBoy)
        {
            var report = new StringBuilder();
            report.AppendLine(String.Format("{0}parkingboy:", IndentString()));

            foreach (var parkinglot in parkingBoy.GetParkinglots())
            {
                report.Append(parkinglot.Print(new Reporter(indentNumber + 1)));
            }
            return report.ToString();
        }

        public string Print(Manager manager)
        {
            var report = new StringBuilder();
            report.AppendLine(String.Format("{0}manager:", IndentString()));

            foreach (var parker in manager.GetParkers())
            {
                report.Append(parker.Print(new Reporter(indentNumber + 1)));
            }
            return report.ToString();
        }

        public string IndentString()
        {
            string tabString = "";
            for (int i = 0; i < indentNumber; i++)
            {
                tabString += "\t";
            }
            return tabString;
        }
    }
}