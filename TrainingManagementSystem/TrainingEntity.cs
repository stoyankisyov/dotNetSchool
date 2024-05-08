namespace TrainingManagementSystem
{
    public abstract class TrainingEntity
    {
        public string? Description { get; set; }

        protected TrainingEntity(string? description)
        {
            Description = description;
        }
    }
}
