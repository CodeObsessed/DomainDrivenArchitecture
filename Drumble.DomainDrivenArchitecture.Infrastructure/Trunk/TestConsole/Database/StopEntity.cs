//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Drumble.DomainDrivenArchitecture.Infrastructure.DataEntities;

//namespace TestConsole.Database
//{
//    public class StopEntity : IDataEntity<Guid>, IDeleteableDataEntity<Guid>
//    {
//        public StopEntity UpdateFrom(Stop stop)
//        {
//            return this;
//        }

//        public static StopEntity CreateFrom(Stop stop)
//        {
//            return new StopEntity();
//        }

//        public Stop HydrateTo()
//        {
//            return new Stop(Guid.NewGuid());
//        }

//        public Guid Id
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

//        public bool IsDeleted
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

//        public Guid DeletedBy
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

//        public DbSet<StopHubEntity> StopHubs { get; set; }
//    }
//}
