using TrainingManagementSystem;

namespace TrainingManagementSystemTests
{
    [TestClass]
    public class PracticalLessonTests
    {
        [TestMethod]
        public void DeepCloneSuccess()
        {
            var practicalLesson = new PracticalLesson("TestDescription", "TestTaskLink", "TestSolutionLink");
            var clone = practicalLesson.Clone();

            Assert.AreNotEqual(practicalLesson, clone);
        }
    }
}
