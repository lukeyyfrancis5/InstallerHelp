
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        [Test]
        public void Add_WhenCalled_SumOfArguments()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Add(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(3)); 

        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnGreater()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Max(2, 1);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Max(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(2));

        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Max(1, 1);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
