using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Models
{
    public class Entity<IdType> where IdType : IComparable
    {
        public IdType Id { get; set; }
    }
}
