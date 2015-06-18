//using RefactorThis.GraphDiff;
//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using Drumble.DomainDrivenArchitecture.Domain.Interfaces;
//using Drumble.DomainDrivenArchitecture.Domain.Models;
//using Drumble.DomainDrivenArchitecture.Domain.Repositories;
//using Drumble.DomainDrivenArchitecture.Infrastructure.DataEntities;

//namespace Drumble.DomainDrivenArchitecture.Infrastructure.EntityFramework
//{
//    public abstract class EntityFrameworkRepository<TDomainEntity, TIdentity, TDataEntity> : IRepository<TDomainEntity, TIdentity>, IAddableRepository<TDomainEntity, TIdentity>, IUpdateableRepository<TDomainEntity, TIdentity>, IDeleteableRepository<TDomainEntity, TIdentity>
//        where TDomainEntity : DomainEntity<TIdentity>, IAggregateRoot
//        where TDataEntity : class, IDataEntity<TIdentity>, new()
//    {
//        protected IUnitOfWork UnitOfWork { get; private set; }

//        protected IEntityMapper<TDomainEntity, TDataEntity> EntityMapper { get; private set; }

//        private List<Expression<Func<TDataEntity, object>>> queryMappings;

//        private Expression<Func<IUpdateConfiguration<TDataEntity>, object>> updateMapping;

//        protected RepositoryContext<TDataEntity> NewContext()
//        {
//            return new RepositoryContext<TDataEntity>(UnitOfWork, updateMapping, queryMappings);
//        }

//        protected EntityFrameworkRepository(
//            IUnitOfWork unitOfWork,
//            IEntityMapper<TDomainEntity, TDataEntity> mapper)
//        {
//            UnitOfWork = unitOfWork;
//            EntityMapper = mapper;

//            queryMappings = new List<Expression<Func<TDataEntity, object>>>();
//        }

//        public virtual TDomainEntity Find(TIdentity id)
//        {
//            throw new NotImplementedException("Provide a concrete implementation of this method!");
//        }

//        public virtual void Add(TDomainEntity item)
//        {
//            if (item == null)
//            {
//                throw new ArgumentException("Cannot add a null entity.");
//            }

//            var entity = EntityMapper.CreateFrom(item);

//            using (var context = NewContext())
//            {
//                context.Add(entity);
//                context.Commit();
//            }
//        }

//        public virtual void Update(TDomainEntity item)
//        {
//            if (item == null)
//            {
//                throw new ArgumentException("Cannot update a null entity.");
//            }

//            var entity = EntityMapper.CreateFrom(item);

//            var updateableDataEntity = entity as IUpdateableDataEntity<TIdentity>;

            
//            if (updateableDataEntity != null)
//            {
//                updateableDataEntity.UpdatedDate = DateTime.UtcNow;
//                entity = (IDataEntity<TIdentity>)updateableDataEntity;
//            }

//            using (var context = NewContext())
//            {
//                context.Update(entity);
//                context.Commit();
//            }
//        }

//        public virtual void Delete(TDomainEntity item)
//        {
//            var entity = EntityMapper.CreateFrom(item);

//            var deleteableDataEntity = entity as IDeleteableDataEntity<TIdentity>;

//            if (deleteableDataEntity != null)
//            {
//                deleteableDataEntity.IsDeleted = true;
//                deleteableDataEntity.DeletedDate = DateTime.UtcNow;
//                entity = deleteableDataEntity;
//            }

//            using (var context = NewContext())
//            {
//                context.Update(entity);
//                context.Commit();
//            }
//        }

//        protected void RegisterQueryMapping(Expression<Func<TDataEntity, object>> mapping)
//        {
//            queryMappings.Add(mapping);
//        }

//        public void RegisterUpdateMapping(Expression<Func<IUpdateConfiguration<TDataEntity>, object>> mapping)
//        {
//            updateMapping = mapping;
//        }
//    }
//}