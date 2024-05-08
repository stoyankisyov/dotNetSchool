using System.Runtime.InteropServices;
using TrainingManagementSystem;

namespace TrainingManagementSystemTests
{
    [TestClass]
    public class LectureTests
    {
        [TestMethod]
        public void DeepCloneSuccess()
        {
            var original = new Lecture("TestDescription", "TestTopic");

            var cloned = original.Clone();

            Assert.IsNotNull(cloned);
            Assert.AreNotSame(original, cloned);
            Assert.AreEqual(original.Description, cloned.Description);
            Assert.AreEqual(original.Topic, cloned.Topic);
        }
    }
}
