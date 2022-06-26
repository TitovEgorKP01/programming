namespace ProcessData
{
    public class FileCSVExport : FileExport
    {
        protected override ITransformer GetTransformer()
        {
            TransformerCreator creator = new CSVTransformerCreator();

            ITransformer transformer = creator.Create();

            return transformer;
        }

        protected override string GetTransformedData(string[,] data, ITransformer transformer)
        {
            string transformedData = transformer.Transform(data);

            return transformedData;
        }

        protected override void WriteData(string data, string category)
        {
            string path = $"../ProcessData/data/{category}_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_CSV.csv";

            File.WriteAllText(path, data);
        }
    }
}