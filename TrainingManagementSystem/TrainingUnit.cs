using TrainingManagementSystem.Interfaces;

namespace TrainingManagementSystem
{
    public abstract class TrainingUnit : TrainingEntity, ITrainingUnitClonable
    {
        protected TrainingUnit(string? description) 
            : base(description)
        {
            
        }

        public abstract TrainingUnit Clone();
    }
}
