namespace TrainingManagementSystem
{
    public abstract class TrainingUnit
    {
        public string? Description { get; set; }

        protected TrainingUnit(string? description)
        {
            Description = description;
        }
    }
}
