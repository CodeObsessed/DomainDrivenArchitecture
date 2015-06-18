using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drumble.DomainDrivenArchitecture.Domain.Interfaces;
using Drumble.DomainDrivenArchitecture.Domain.Models;
using Drumble.DomainDrivenArchitecture.Domain.Repositories;
using Drumble.DomainDrivenArchitecture.Infrastructure.DataEntities;
using Drumble.DomainDrivenArchitecture.Infrastructure.EntityFramework;

namespace Drumble.DomainDrivenArchitecture.Infrastructure
{
    public abstract class EntityFrameworkRepository<TDomainEntity, TIdentity>
        where TDomainEntity : DomainEntity<TIdentity>, IAggregateRoot
        //where TDataEntity : class, IDataEntity<TIdentity>, new()
    {
        protected IUnitOfWork UnitOfWork { get; private set; }

        //protected IEntityMapper<TDomainEntity, TDataEntity> EntityMapper { get; private set; }

        protected EntityFrameworkRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            //EntityMapper = mapper;
        }

        //protected RepositoryContext<TDataEntity> NewContext()
        //{
        //    return new RepositoryContext<TDataEntity>(UnitOfWork);
        //}

    }



 

}
