using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class VideoServiceTests
    {
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            // Arrange
            var service = new VideoService();

            // Replace FakeFileReader with real FileReader
            service.FileReader = new FakeFileReader();

            // Act
            var result = service.ReadVideoTitle();

            // Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
