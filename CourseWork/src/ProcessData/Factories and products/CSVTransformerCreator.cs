namespace ProcessData
{
    public class CSVTransformerCreator : TransformerCreator
    {
        public override ITransformer Create()
        {
            ITransformer csvTransformer = new CSVTransformer();

            return csvTransformer;
        }
    }
}