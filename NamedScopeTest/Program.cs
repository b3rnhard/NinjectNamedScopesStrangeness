using System;
using System.Threading;
using System.Threading.Tasks;
using Ninject;

namespace NamedScopeTest
{
    internal static class Program
    {
        public static void Main()
        {
            // Simulate heavy load, collect frequently
            var task = new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);

                    Console.WriteLine("test");
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                    GC.WaitForPendingFinalizers();
                }
            });

            task.Start();

            var settings = new NinjectSettings {CachePruningInterval = new TimeSpan(0, 0, 5)};
            IKernel kernel = new StandardKernel(settings, new NinjectBindingsModule());

            PrintLoadedModules(kernel);

            var processor = kernel.Get<IMainProcessor>();
            processor.ProcessOnce();
            processor.ProcessOnce(); // second time is successful just as much
            Thread.Sleep(5000);

            var processor2 = kernel.Get<IMainProcessor>();
            processor2.ProcessOnce(); // ScopeDisposedException
        }

        private static void PrintLoadedModules(IKernel kernel)
        {
            Console.WriteLine("Loaded Ninject Kernel modules:");
            foreach (var module in kernel.GetModules())
                Console.WriteLine("{0}", module.Name);
            Console.WriteLine();
        }
    }
}