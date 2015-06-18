using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drumble.DomainDrivenArchitecture.Domain.Models;

namespace TestConsole
{
    public class Stop : DomainEntity<Guid>, IAggregateRoot
    {
        public string Name { get; set; }
        
        public Stop(Guid id)
            : base(id)
        { 
            Name = "none";
            Hubs = new List<string>();

            Hubs.Add("my hub");
            Hubs.Add("your hub");
        }

        public List<string> Hubs { get; set; }
    }
}
