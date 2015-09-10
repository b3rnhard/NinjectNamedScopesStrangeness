namespace NamedScopeTest
{
    public sealed class PrimaryProcessor : IPrimaryProcessor
    {
        private readonly ISecondaryProcessor _secondaryProcessor;

        public PrimaryProcessor(ISecondaryProcessor secondaryProcessor)
        {
            _secondaryProcessor = secondaryProcessor;
        }

        public void Process()
        {
            _secondaryProcessor.Process();
        }
    }
}
