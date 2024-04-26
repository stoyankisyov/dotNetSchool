using TrainingManagementSystem;

namespace TrainingManagementSystemTests
{
    [TestClass]
    public class PracticalLessonTests
    {
        [TestMethod]
        public void CloneSuccess()
        {
            var practicalLesson = new PracticalLesson("TestDescription", "TestTaskLink", "TestSolutionLink");
            var clone = practicalLesson.Clone();

            Assert.AreNotEqual(practicalLesson, clone);
        }
    }
}
