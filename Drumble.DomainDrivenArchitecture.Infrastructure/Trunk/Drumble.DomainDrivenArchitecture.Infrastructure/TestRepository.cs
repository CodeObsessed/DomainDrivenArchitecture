//using RefactorThis.GraphDiff;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using Drumble.DomainDrivenArchitecture.Domain.EntityFramework;
//using Drumble.DomainDrivenArchitecture.Domain.Interfaces;
//using Drumble.DomainDrivenArchitecture.Domain.Models;
//using Drumble.DomainDrivenArchitecture.Infrastructure.EntityFramework;

//namespace Drumble.DomainDrivenArchitecture.Infrastructure
//{
//    public class TestEntity : DomainEntity<Guid>, IAggregateRoot
//    {
//        public TestEntity(Guid id) : base(id) { }
    
//    }
//    public class TestDataEntity : IDataEntity<Guid>, IDeleteableDataEntity, IUpdateableDataEntity
//    {
//        public Guid Id
//        {
//            get { throw new NotImplementedException(); }
//        }

//        public DateTime DeletedDate
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//            set
//            {
//                throw new NotImplementedException();
//            }
//        }

//        public DateTime UpdatedDate
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//            set
//            {
//                throw new NotImplementedException();
//            }
//        }
//    }

//    public interface IDeleteableDataEntity
//    {
//        bool IsDeleted { get; set; }

//        DateTime DeletedDate { get; set; }

//        Guid DeletedBy { get; set; }
//    }

//    public interface IUpdateableDataEntity
//    {
//        DateTime UpdatedDate { get; set; }
//    }

//    public interface IRepository<TDomainEntity, TIdentity>
//        where TDomainEntity : DomainEntity<TIdentity>, IAggregateRoot
//    {}

//    public interface ITestRepository : IFindableRepository<TestEntity, Guid>, IDeleteableRepository<TestEntity, Guid>, IUpdateableRepository<TestEntity, Guid>
//    { }


//    public abstract class EntityFrameworkRepository<TDomainEntity, TIdentity, TDataEntity>
//        : IUpdateableRepository<TDomainEntity, TIdentity>, IFindableRepository<TDomainEntity, TIdentity>, IUpdateableRepository<TDomainEntity, TIdentity> //: IRepository<TDomainEntity, TIdentity>, IFindableRepository<TDomainEntity, TIdentity>, IDeleteableRepository<TDomainEntity, TIdentity> //: IRepository<TDomainEntity, TIdentity>, IFindableRepository<TDomainEntity, TIdentity>
//            where TDomainEntity : DomainEntity<TIdentity>, IAggregateRoot
//            where TDataEntity : class, IUpdateableDataEntity, IDataEntity<TIdentity>, new()
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

      
//        public virtual void Update(TDomainEntity item)
//        {
//            if (item == null)
//            {
//                throw new ArgumentException("Cannot update a null entity.");
//            }

//            var entity = EntityMapper.CreateFrom(item);
//            entity.UpdatedDate = DateTime.UtcNow;

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

//        public TDomainEntity Find(TIdentity id)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class TestRepository : EntityFrameworkRepository<TestEntity, Guid, TestDataEntity>, ITestRepository
//    {
//        public TestRepository(IUnitOfWork unitOfWork, IEntityMapper<TestEntity, TestDataEntity> entityMapper)
//            : base(unitOfWork, entityMapper)
//        {

//        }

//    }

//    public class TempTesting
//    {
//        public TempTesting()
//        {

//            var repo = new TestRepository(new EntityFrameworkUnitOfWork<MyContext>(), new TestEntityMapper());

//            var ef = repo.Find(Guid.NewGuid());
//            /repo.Update();
            
//        }
//    }

//    public class TestEntityMapper : IEntityMapper<TestEntity, TestDataEntity>
//    {
//        public TestEntity CreateFrom(TestDataEntity dataEntity)
//        {
//            throw new NotImplementedException();
//        }

//        public TestDataEntity CreateFrom(TestEntity domainEntity)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class MyContext : EntityFrameworkContext
//    { }
//}
