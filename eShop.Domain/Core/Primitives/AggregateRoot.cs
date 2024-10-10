namespace eShop.Domain.Core.Primitives
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<DomainEvent> _events = [];

        public IReadOnlyCollection<DomainEvent> Events => _events.AsReadOnly();

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

        protected void RaiseDomainEvent(DomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }
    }
}
