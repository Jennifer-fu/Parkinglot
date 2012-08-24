namespace ParkingLot
{
    public class Reporter
    {

        public Reporter(int indentNumber)
        {
            IndentNumber = indentNumber;
        }

        public int IndentNumber { get; private set; }


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