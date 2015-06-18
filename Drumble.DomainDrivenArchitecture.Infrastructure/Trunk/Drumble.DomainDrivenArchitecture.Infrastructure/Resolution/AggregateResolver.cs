using Microsoft.Practices.Unity;
using Drumble.DomainDrivenArchitecture.Domain.EntityFramework;
using Drumble.DomainDrivenArchitecture.Domain.Interfaces;
using Drumble.DomainDrivenArchitecture.Infrastructure.EntityFramework;

namespace Drumble.DomainDrivenArchitecture.Infrastructure.Resolution
{
    public class AggregateResolver<TContext>
        where TContext : EntityFrameworkContext
    {
        protected IUnityContainer Container { get; private set; }

        protected string ContextRegistrationName { get; private set; }

        public AggregateResolver(IUnityContainer container)
        {
            Container = container;
            ContextRegistrationName = typeof(TContext).Name;

            Container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork<TContext>>(
                ContextRegistrationName
            );
        }

        public AggregateResolver<TContext> RegisterAggregate<TDomainEntity, TDataEntity, TMapper, TRepositoryInterface, TRepositoryImplementation>()
            where TMapper : IEntityMapper<TDomainEntity, TDataEntity>
            where TRepositoryImplementation : TRepositoryInterface
        {
            Container.RegisterType<IEntityMapper<TDomainEntity, TDataEntity>, TMapper>(new TransientLifetimeManager());

            Container.RegisterType<TRepositoryInterface, TRepositoryImplementation>(
                new InjectionConstructor(
                    new ResolvedParameter<IUnitOfWork>(ContextRegistrationName),
                    new ResolvedParameter<IEntityMapper<TDomainEntity, TDataEntity>>()
                )
            );

            return this;
        }

        public AggregateResolver<TContext> RegisterReadOnlyAggregate<TDomainEntity, TDataEntity, TMapper, TRepositoryInterface, TRepositoryImplementation>()
            where TMapper : IReadOnlyEntityMapper<TDomainEntity, TDataEntity>
            where TRepositoryImplementation : TRepositoryInterface
        {
            Container.RegisterType<IReadOnlyEntityMapper<TDomainEntity, TDataEntity>, TMapper>(new TransientLifetimeManager());
            Container.RegisterType<TRepositoryInterface, TRepositoryImplementation>(
                new InjectionConstructor(
                    new ResolvedParameter<IUnitOfWork>(ContextRegistrationName),
                    new ResolvedParameter<IReadOnlyEntityMapper<TDomainEntity, TDataEntity>>()
                )
            );

            return this;
        }

        public AggregateResolver<TContext> RegisterAggregateWithValueProvider<TDomainEntity, TDataEntity, TMapper, TRepositoryInterface, TRepositoryImplementation, TValueProviderInterface, TValueProviderImplementation>()
            where TMapper : IEntityMapper<TDomainEntity, TDataEntity>
            where TRepositoryImplementation : TRepositoryInterface
            where TValueProviderImplementation : TValueProviderInterface
        {
            Container.RegisterType<IEntityMapper<TDomainEntity, TDataEntity>, TMapper>(new TransientLifetimeManager());
            Container.RegisterType<TValueProviderInterface, TValueProviderImplementation>(new TransientLifetimeManager());
            Container.RegisterType<TRepositoryInterface, TRepositoryImplementation>(
                new InjectionConstructor(
                    new ResolvedParameter<IUnitOfWork>(ContextRegistrationName),
                    new ResolvedParameter<IEntityMapper<TDomainEntity, TDataEntity>>(),
                    new ResolvedParameter<TValueProviderInterface>()
                )
            );

            return this;
        }

        public AggregateResolver<TContext> RegisterReadOnlyAggregateWithValueProvider<TDomainEntity, TDataEntity, TMapper, TRepositoryInterface, TRepositoryImplementation, TValueProviderInterface, TValueProviderImplementation>()
            where TMapper : IReadOnlyEntityMapper<TDomainEntity, TDataEntity>
            where TRepositoryImplementation : TRepositoryInterface
            where TValueProviderImplementation : TValueProviderInterface
        {
            Container.RegisterType<IReadOnlyEntityMapper<TDomainEntity, TDataEntity>, TMapper>(
                new TransientLifetimeManager(),
                new InjectionConstructor(
                    new ResolvedParameter<TValueProviderInterface>()
                    )
                );
            Container.RegisterType<TValueProviderInterface, TValueProviderImplementation>(new TransientLifetimeManager());
            Container.RegisterType<TRepositoryInterface, TRepositoryImplementation>(
                new InjectionConstructor(
                    new ResolvedParameter<IUnitOfWork>(ContextRegistrationName),
                    new ResolvedParameter<IReadOnlyEntityMapper<TDomainEntity, TDataEntity>>(),
                    new ResolvedParameter<TValueProviderInterface>()
                )
            );

            return this;
        }
    }
}