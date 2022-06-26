namespace ProcessData
{
    public abstract class FileExport
    {
        public void Export(string category, RepositoryFacade rep)
        {
            string[,] data = GetData(category, rep);
            ITransformer transformer = GetTransformer();
            string transformedData = GetTransformedData(data, transformer);
            WriteData(transformedData, category);
        }

        protected abstract ITransformer GetTransformer();

        protected string[,] GetData(string category, RepositoryFacade rep)
        {
            return rep.GetAllCategoryData(category);
        }

        protected abstract string GetTransformedData(string[,] data, ITransformer transformer);

        protected abstract void WriteData(string data, string category);
    }
}