namespace TechnicalAssessment.Core.Entity
{
    public abstract class Entity : IEntity
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        protected Entity()
        {
            Id = "";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
