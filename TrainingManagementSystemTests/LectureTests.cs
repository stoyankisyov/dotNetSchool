using TrainingManagementSystem;

namespace TrainingManagementSystemTests
{
    [TestClass]
    public class LectureTests
    {
        [TestMethod]
        public void CloneSuccess()
        {
            var lecture = new Lecture("TestDescription", "TestTopic");
            var clonedLecture = lecture.Clone();

            Assert.AreNotEqual(lecture, clonedLecture);
        }
    }
}
