namespace TrainingManagementSystem
{
    public class PracticalLesson : TrainingUnit
    {
        public string? TaskLink { get; set; }
        public string? SolutionLink { get; set; }

        public PracticalLesson(string? description, string? taskLink, string? solutionLink)
            : base(description)
        {
            TaskLink = taskLink;
            SolutionLink = solutionLink;
        }

        public override PracticalLesson Clone()
        {
            return new PracticalLesson(Description, TaskLink, SolutionLink);
        }
    }
}
