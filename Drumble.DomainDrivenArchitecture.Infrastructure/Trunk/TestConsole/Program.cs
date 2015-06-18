using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Database2;
using Drumble.DomainDrivenArchitecture.Infrastructure.EntityFramework;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IStopRepository stopRepository = new StopRepository(new EntityFrameworkUnitOfWork<DDArchTest2Entities>());

            stopRepository.Add(new Stop(Guid.NewGuid()) { Name = "Console bitches" });



            var stop = stopRepository.Find(Guid.Parse("21BAAD02-CBB6-4697-9B96-6BC2F796FE18"));

            stop.Hubs = new List<string>() { "new hub!" };

            stopRepository.Update(stop);
        }
    }
}
