namespace Lab_2
{
    public delegate void FillingHandle(RefuelingOperator oper, FillingEventArgs chargs);


    class Program
    {
        static void Main(string[] args)
        {
            RefuelingOperator oper = new RefuelingOperator("Taras", "Bulba");

            FillStation station = new FillStation(oper);

            oper.FillUp();
        }
    }
}
