namespace ProcessData
{
    public class FileTSVExport : FileExport
    {
        protected override ITransformer GetTransformer()
        {
            TransformerCreator creator = new TSVTransformerCreator();

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
            string path = $"../ProcessData/data/{category}_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_TSV.tsv";

            File.WriteAllText(path, data);
        }
    }
}