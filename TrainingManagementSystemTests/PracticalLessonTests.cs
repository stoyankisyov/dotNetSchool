using TrainingManagementSystem;

namespace TrainingManagementSystemTests
{
    [TestClass]
    public class PracticalLessonTests
    {
        [TestMethod]
        public void DeepCloneSuccess()
        {
            var original = new PracticalLesson("TestDescription", "TestTaskLink", "TestSolutionLink");

            var cloned = original.Clone();

            Assert.IsNotNull(cloned);
            Assert.AreNotSame(original, cloned);
            Assert.AreEqual(original.Description, cloned.Description);
            Assert.AreEqual(original.TaskLink, cloned.TaskLink);
            Assert.AreEqual(original.SolutionLink, cloned.SolutionLink);
        }
    }
}
