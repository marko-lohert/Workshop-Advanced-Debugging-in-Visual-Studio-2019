using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSharp.Shared.Utility;

namespace PeopleSharp.Server.Tests
{
    [TestClass]
    public class PersonalNameUtility_Tests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            personalNameUtility = new();
        }

        private static PersonalNameUtility personalNameUtility;

        [TestMethod]
        public void CapitalizeEachWord_First_Last()
        {
            // Arrange
            string inputText = "john doe";
            string expectedOutputTest = "John Doe";

            // Act
            string actualOutputTest = personalNameUtility.CapitalizeEachWord(inputText);

            // Assert
            Assert.AreEqual(expectedOutputTest, actualOutputTest);
        }

        [TestMethod]
        public void CapitalizeEachWord_First_Initial_Last()
        {
            // Arrange
            string inputText = "john l. doe";
            string expectedOutputTest = "John L. Doe";

            // Act
            string actualOutputTest = personalNameUtility.CapitalizeEachWord(inputText);

            // Assert
            Assert.AreEqual(expectedOutputTest, actualOutputTest);
        }

        [TestMethod]
        public void CapitalizeEachWord_Space_First_TwoSpaces_Last()
        {
            // Arrange
            string inputText = "john  doe";
            string expectedOutputTest = "John  Doe";

            // Act
            string actualOutputTest = personalNameUtility.CapitalizeEachWord(inputText);

            // Assert
            Assert.AreEqual(expectedOutputTest, actualOutputTest);
        }

        [TestMethod]
        public void CapitalizeEachWord_EmptyString()
        {
            // Arrange
            string inputText = string.Empty;
            string expectedOutputTest = string.Empty;

            // Act
            string actualOutputTest = personalNameUtility.CapitalizeEachWord(inputText);

            // Assert
            Assert.AreEqual(expectedOutputTest, actualOutputTest);
        }
    }
}
