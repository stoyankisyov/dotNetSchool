using System.Reflection.Metadata;
using System.Runtime.InteropServices;
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
            var original = new Training("TestDescription");
            original.Add(new Lecture("TestLectureDescription", "TestLectureTopic"));
            original.Add(new PracticalLesson("TestDescription", "TestTaskLink", "TestSolutionLink"));

            var cloned = original.Clone();

            Assert.IsNotNull(cloned);
            Assert.AreNotSame(original, cloned);
            Assert.AreEqual(original.Description, cloned.Description);

            Assert.AreNotSame(original.TrainingUnits, cloned.TrainingUnits);

            for (int i = 0; i < original.TrainingUnits.Length; i++)
            {
                var originalUnit = original.TrainingUnits[i];
                var clonedUnit = cloned.TrainingUnits[i];

                if (originalUnit is Lecture)
                {
                    Assert.AreEqual((originalUnit as Lecture)?.Description, (clonedUnit as Lecture)?.Description);
                    Assert.AreEqual((originalUnit as Lecture)?.Topic, (clonedUnit as Lecture)?.Topic);
                }
                else if (originalUnit is PracticalLesson)
                {
                    Assert.AreEqual((originalUnit as PracticalLesson)?.Description, (clonedUnit as PracticalLesson)?.Description);
                    Assert.AreEqual((originalUnit as PracticalLesson)?.TaskLink, (clonedUnit as PracticalLesson)?.TaskLink);
                    Assert.AreEqual((originalUnit as PracticalLesson)?.SolutionLink, (clonedUnit as PracticalLesson)?.SolutionLink);
                }
            }
        }
    }
}