namespace ProcessData
{
    public class CSVTransformer : ITransformer 
    {
        public string Transform(string[,] data)
        {
            string transformedData = "";

            for (int i = 0; i < data.GetLength(0); i++)
            {
                string[] row = new string[data.GetLength(1)];

                for (int j = 0; j < data.GetLength(1); j++)
                {
                    row[j] = data[i, j];
                }

                transformedData += String.Join(',', row);
                transformedData += "\n";
            }

            return transformedData;
        }
    }
}