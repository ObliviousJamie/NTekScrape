using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NTekScrape.Core.Interfaces;
using NTekScrape.Core.Movelist;
using NTekScrape.Core.Scraper;
using Xunit;

namespace NTekScrape.Core.Tests
{
    public class FrameDataRequesterTests
    {
        [Theory]
        [InlineData("josie")]
        [InlineData("lei")]
        [InlineData("devil-jin")]
        public void GetCharacter_WithStringParameter_CallsDownload(string character)
        {
            // Arrange
            var mockScraper = new Mock<IScraper>();
            mockScraper.Setup(m => m.Download(It.IsAny<string>())).Returns(new Moveset { Name = "Test Moveset" });

            var sut = new FrameDataRequester(FrameDataSource.Default, mockScraper.Object);

            // Act
            sut.GetCharacter(character);

            //Assert
            mockScraper.Verify(s => s.Download(character));
        }

        [Theory]
        [InlineData(Character.Josie)]
        [InlineData(Character.Lei)]
        public void GetCharacter_WithEnumParameter_CallsDownload(Character character)
        {
            // Arrange
            var mockScraper = new Mock<IScraper>();
            mockScraper.Setup(m => m.Download(It.IsAny<string>())).Returns(new Moveset { Name = "Test Moveset" });

            var sut = new FrameDataRequester(FrameDataSource.Default, mockScraper.Object);

            // Act
            sut.GetCharacter(character);

            var stringCharacter = character.ToString().ToLower();

            //Assert
            mockScraper.Verify(s => s.Download(stringCharacter));
        }

        [Fact]
        public void GetCharacters_WithNoParameters_CallsDownload()
        {
            // Arrange
            var mockScraper = new Mock<IScraper>();
            mockScraper.Setup(m => m.Download(It.IsAny<string>())).Returns(new Moveset { Name = "Test Moveset" });

            var sut = new FrameDataRequester(FrameDataSource.Default, mockScraper.Object);

            // Act
            sut.GetCharacters().ToList();

            //Assert
            mockScraper.Verify(s => s.Download("josie"));
            mockScraper.Verify(s => s.Download("lei"));
            mockScraper.Verify(s => s.Download("devil-jin"));
        }
    }
}
