namespace TechnicalAssessment.Core.Entity
{
    public interface IEntity
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
