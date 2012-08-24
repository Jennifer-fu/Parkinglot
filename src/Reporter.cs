using System;
using System.Text;

namespace ParkingLot
{
    public class Reporter
    {

        public Reporter(int indentNumber)
        {
            IndentNumber = indentNumber;
        }

        public int IndentNumber { get; private set; }


        public string Print(Manager manager)
        {
            var report = new StringBuilder();
            report.AppendLine(String.Format("{0}manager:", Indent()));

            foreach (var parker in manager.GetParkers())
            {
                report.Append(parker.Print(new Reporter(IndentNumber + 1)));
            }
            return report.ToString();
        }

        public string Indent()
        {
            string tabString = "";
            for (int i = 0; i < IndentNumber; i++)
            {
                tabString += "\t";
            }
            return tabString;
        }

        public string BackIndent()
        {
            string tabString = "";
            for (int i = 0; i < IndentNumber; i++)
            {
                tabString += "\t";
            }
            return tabString;
        }
    }
}