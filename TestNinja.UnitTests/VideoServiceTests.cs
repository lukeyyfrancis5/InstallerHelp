using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepo> _repo;
        private VideoService _videoService;
        

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _fileReader = new Mock<IFileReader>();
            _repo = new Mock<IVideoRepo>();
            // Gets real FileReader
            _videoService = new VideoService(_fileReader.Object, _repo.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            // When calling Read Method with this arguement return string
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            
            // Act
            var result = _videoService.ReadVideoTitle();

            // Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _repo.Setup(r => r.GetUnprocessedVids()).Returns(new List<Video>());

            var result =_videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringOfIdOfUnprocessedVideos()
        {
            // Arrange
            _repo.Setup(r => r.GetUnprocessedVids()).Returns(new List<Video>
            {
                new Video { Id = 1 },
                new Video { Id = 2 },
                new Video { Id = 3 },
            });

            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            // Assert
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
