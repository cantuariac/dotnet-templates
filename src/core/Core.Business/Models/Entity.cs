using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Models
{
    public abstract class Entity<IdType> : IValidable where IdType : IComparable
    {
        public IdType Id { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }

    public interface IValidable
    {
        public bool IsValid();
    }
}
