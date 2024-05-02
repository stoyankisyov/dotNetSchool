using System.Diagnostics.Contracts;

namespace TrainingManagementSystem
{
    public class Training : TrainingEntity
    {
        private int _trainingUnitCount;

        public TrainingUnit[] TrainingUnits { get; private set; }

        public Training(string? description)
            : base(description)
        {
            TrainingUnits = new TrainingUnit[1];
            _trainingUnitCount = 0;
        }

        public void Add(TrainingUnit newTrainingUnit)
        {
            if (_trainingUnitCount == TrainingUnits.Length)
            {
                ResizeTrainingUnitsArray();
            }

            TrainingUnits[_trainingUnitCount++] = newTrainingUnit;
        }

        public bool IsPractical()
        {
            foreach (var trainingUnit in TrainingUnits)
            {
                if (trainingUnit is Lecture)
                {
                    return false;
                }
            }

            return true;
        }

        private void ResizeTrainingUnitsArray()
        {
            var newResizedTrainingUnitsArray = new TrainingUnit[TrainingUnits.Length * 2];
            Array.Copy(TrainingUnits, newResizedTrainingUnitsArray, _trainingUnitCount);
            TrainingUnits = newResizedTrainingUnitsArray;
        }

        public Training Clone()
        {
            var clone = new Training(Description);

            foreach (var trainingUnit in TrainingUnits)
            {
                if (trainingUnit is not null)
                {
                    clone.Add(trainingUnit.Clone());
                }
            }

            return clone;
        }
    }
}
