namespace ProcessData
{
    public class TSVTransformerCreator : TransformerCreator
    {
        public override ITransformer Create()
        {
            ITransformer tsvTransformer = new TSVTransformer();

            return tsvTransformer;
        }
    }
}