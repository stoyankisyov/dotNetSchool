using TrainingManagementSystem;

namespace TrainingManagementSystemTests
{
    [TestClass]
    public class LectureTests
    {
        [TestMethod]
        public void DeepCloneSuccess()
        {
            var lecture = new Lecture("TestDescription", "TestTopic");
            var clonedLecture = lecture.Clone();

            Assert.AreNotEqual(lecture, clonedLecture);
        }
    }
}
