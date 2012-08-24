namespace ParkingLot
{
    public class Reporter
    {
        private int indentNumber = -1;

        public void Indent()
        {
            indentNumber++;
        }
            
        public void Outdent()
        {
            indentNumber--;
        }

        public string FormatString()
        {
            var tabString = string.Empty;
            for (var i = 0; i < indentNumber; i++)
            {
                tabString += "\t";
            }
            return tabString;
        }
    }
}