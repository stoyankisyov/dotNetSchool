using System.Reflection.Metadata;
using TrainingManagementSystem;

namespace TrainingManagementSystemTests
{
    [TestClass]
    public class TrainingTests
    {
        [TestMethod]
        public void TrainingUnitsArrayResizeTestSuccess()
        {
            var training = new Training("TestDescription");
            training.Add(new Lecture("TestDescription", "TestTopic"));
            training.Add(new Lecture("TestDescription", "TestTopic"));
            training.Add(new Lecture("TestDescription", "TestTopic"));

            Assert.AreEqual(4, training.TrainingUnits.Length);
        }

        [TestMethod]
        public void TrainingUnitsAddTestSuccess()
        {
            var training = new Training("TestDescription");
            var lecture = new Lecture("TestDescription", "TestTopic");
            training.Add(lecture);

            Assert.AreEqual(lecture, training.TrainingUnits[0]);
        }

        [TestMethod]
        public void IsPracticalTestPossitive()
        {
            var training = new Training("TestDescription");
            training.Add(new PracticalLesson("TestDescription", "TestLink", "TestSolutionLink"));

            Assert.IsTrue(training.IsPractical());
        }

        [TestMethod]
        public void IsPracticalTestNegative()
        {
            var training = new Training("TestDescription");
            training.Add(new PracticalLesson("TestDescription", "TestLink", "TestSolutionLink"));
            training.Add(new Lecture("TestDescription", "TestTopic"));

            Assert.IsFalse(training.IsPractical());
        }

        [TestMethod]
        public void DeepCloneSuccess() 
        {
            var training = new Training("TestDescription");
            var clone = training.Clone();

            Assert.AreNotEqual(clone, training);
        }
    }
}