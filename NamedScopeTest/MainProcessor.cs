using System;

namespace NamedScopeTest
{
    public sealed class MainProcessor : IMainProcessor {
        private static int ins = 0;
        private int instance;
        private ISecondaryProcessor _secondaryProcessor;

        public MainProcessor(ISecondaryProcessor secondaryProcessor) {
            instance = ins++;
            _secondaryProcessor = secondaryProcessor;
        }

        ~MainProcessor() {
            Console.WriteLine(string.Format("MainProcessor instance {0} disposed.", instance));
        }

        public void ProcessOnce() {
            _secondaryProcessor.ProcessOnce();
        }
    }
}