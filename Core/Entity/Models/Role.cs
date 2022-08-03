using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrate
{
    public class Role:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
