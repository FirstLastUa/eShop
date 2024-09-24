namespace eShop.Domain.Core.Primitives
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(Guid id)
            : base(id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        /// <remarks>
        /// Required by EF Core.
        /// </remarks>
        protected AggregateRoot()
        {
        }
    }
}
