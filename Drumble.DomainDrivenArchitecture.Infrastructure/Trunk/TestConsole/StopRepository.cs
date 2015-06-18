using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using TestConsole.Database2;
using Drumble.DomainDrivenArchitecture.Domain.Interfaces;
using Drumble.DomainDrivenArchitecture.Infrastructure;
using Drumble.DomainDrivenArchitecture.Infrastructure.EntityFramework;

namespace TestConsole
{
    public class StopRepository : EntityFrameworkRepository<Stop, Guid>, IStopRepository
    {
        public StopRepository(
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }


        public IReadOnlyCollection<Stop> GetAll()
        {
            using (var context = new DDArchTest2Entities())
            {
                return context
                    .StopEntities
                    .Include(x => x.StopHubs)
                   // .Where(x => !x.IsDeleted)
                    .Select(x => x.HydrateTo())
                    .ToList();
            }
        }

        public Stop Find(Guid id)
        {
            using (var context = new DDArchTest2Entities())
            {
                var dataEntity = context
                    .StopEntities
                    .Include(x => x.StopHubs)
                    .SingleOrDefault(x => x.Id == id).HydrateTo();

                return dataEntity;

            }
        }

        public void Delete(Stop item)
        {
            throw new NotImplementedException();
        }

        public void Update(Stop item)
        {
            using (var context = new DDArchTest2Entities())
            {
                var dataEntity = context
                    .StopEntities
                    .Include(x => x.StopHubs)
                    .SingleOrDefault(x => x.Id == item.Id);

                //dataEntity.UpdateFrom(item);

                context.SaveChanges();
            }
        }

        public void Add(Stop item)
        {
            using (var context = new DDArchTest2Entities())
            {
                //var dataEntity = new StopEntity() 
                //{ 
                //    Id = item.Id, 
                //    Name = item.Name, 
                //    StopHubs = new List<StopHubEntity>() { new StopHubEntity() { HubName = "hub!"} }
                //};

                var entity = StopEntity.CreateFrom(item);

                context.StopEntities.Add(entity);
                context.SaveChanges();
            }
        }
    }
}
