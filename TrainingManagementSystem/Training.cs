namespace TrainingManagementSystem
{
    public class Training
    {
        private int _trainingUnitCount;

        public string? Description { get; set; }
        public TrainingUnit[] TrainingUnits { get; private set; }

        public Training(string? description)
        {
            Description = description;
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

        public Training Clone()
        {
            var clone = new Training(Description);

            for (int i = 0; i < _trainingUnitCount; i++)
            {
                if (TrainingUnits[i] is Lecture lecture)
                {
                    clone.Add(lecture.Clone());
                }
                else if (TrainingUnits[i] is PracticalLesson practicalLesson)
                {
                    clone.Add(practicalLesson.Clone());
                }
            }

            return clone;
        }

        private void ResizeTrainingUnitsArray()
        {
            var newResizedTrainingUnitsArray = new TrainingUnit[TrainingUnits.Length * 2];
            Array.Copy(TrainingUnits, newResizedTrainingUnitsArray, _trainingUnitCount);
            TrainingUnits = newResizedTrainingUnitsArray;
        }
    }
}
