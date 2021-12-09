namespace Core.Business.Models
{
    public abstract class Entity<IdType> where IdType : IComparable
    {
        public IdType Id { get; set; }
    }
}
