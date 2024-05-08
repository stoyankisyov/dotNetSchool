namespace TrainingManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var oopTraining = new Training("Classes and objects");
            oopTraining.Add(new Lecture("Introduction to OOP", "Constructors and properties"));
            oopTraining.Add(new PracticalLesson("Create a class with properties", "https//:TrainingTask", "https//:Solution"));

            // Resize check -> resizes to 4 after next line
            oopTraining.Add(new Lecture("Public, private, internal, protected, sealed", "Access modifiers"));

            var isPractical = oopTraining.IsPractical();

            // Deep clone check -> different references
            var newOopTraining = oopTraining.Clone();
            var oopTrainingReference = oopTraining.GetHashCode();
            var newTrainingReference = newOopTraining.GetHashCode();
        }
    }
}
