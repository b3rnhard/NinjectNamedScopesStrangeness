namespace NamedScopeTest
{
    public sealed class Data : IData
    {
        private readonly object _data;

        public Data()
        {
            _data = new object();
        }

        public object RetrieveImportantInformation()
        {
            return _data;
        }
    }
}