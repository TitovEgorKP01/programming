namespace ProcessData
{
    public interface ITransformer
    {
        public string Transform(string[,] data);
    }
}