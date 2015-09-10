using Ninject.Extensions.Factory;
using Ninject.Extensions.NamedScope;
using Ninject.Modules;

namespace NamedScopeTest
{
    public sealed class NinjectBindingsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainProcessor>().To<MainProcessor>().DefinesNamedScope("TheScope");
            Bind<ISecondaryProcessor>().To<SecondaryProcessor>().InSingletonScope();

            Bind<IDataFactory>().ToFactory().InTransientScope();
            Bind<IData>().To<Data>().InNamedScope("TheScope");
        }
    }
}