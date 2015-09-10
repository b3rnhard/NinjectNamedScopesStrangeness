namespace NamedScopeTest
{
    public sealed class SecondaryProcessor : ISecondaryProcessor
    {
        private readonly IDataFactory _dataFactory;

        public SecondaryProcessor(IDataFactory dataFactory)
        {
            _dataFactory = dataFactory;
        }

        public void ProcessOnce()
        {
            object obj = _dataFactory.CreateData().RetrieveImportantInformation();
        }
    }
}