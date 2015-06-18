using Microsoft.Practices.Unity;

namespace Drumble.DomainDrivenArchitecture.Infrastructure.Resolution
{
    public class ServiceResolver
    {
        protected IUnityContainer Container { get; private set; }

        public ServiceResolver(IUnityContainer container)
        {
            Container = container;
        }

        public void RegisterService<TInterface, TImplementation>()
            where TImplementation : TInterface
        {
            Container.RegisterType<TInterface, TImplementation>(new TransientLifetimeManager());
        }
    }
}