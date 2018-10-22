using System;
using System.Linq;
using HtmlAgilityPack;
using Moq;
using NTekScrape.Core.Interfaces;
using Xunit;

namespace NTekScrape.Core.Tests.Scraper
{
    public class RbnorwayScraperTests
    {
        [Theory]
        [InlineData("josie")]
        [InlineData("lei")]
        public void Download_CallWithCharacterName_CallsHtmlWebWrapper(string character)
        {
            // Arrange
            var htmlMock = new Mock<IHtmlWebWrapper>();
            htmlMock.Setup(doc => doc.GetHtmlDocument(It.IsAny<string>())).Returns(LoadDocument(character));

            var rbnorwayDownloader = new RbnorwayScraper(htmlMock.Object);

            // Act
            rbnorwayDownloader.Download(character);

            //Assert
            htmlMock.Verify(h => h.GetHtmlDocument(It.Is<string>(s => s.Contains(character))));
        }

        [Theory]
        [InlineData("josie")]
        [InlineData("lei")]
        public void Download_CallWithCharacterName_ReturnsNonEmptyObject(string character)
        {
            // Arrange
            var htmlMock = new Mock<IHtmlWebWrapper>();
            htmlMock.Setup(doc => doc.GetHtmlDocument(It.IsAny<string>())).Returns(LoadDocument(character));

            var sut = new RbnorwayScraper(htmlMock.Object);

            // Act
            var data = sut.Download(character);

            //Assert
            Assert.NotNull(data.Name);
            Assert.True(data.Moves.Any());
        }

        [Fact]
        public void Download_CallWithJosie_ReturnsCorrectProperties()
        {
            var character = "josie";
            // Arrange
            var htmlMock = new Mock<IHtmlWebWrapper>();
            htmlMock.Setup(doc => doc.GetHtmlDocument(It.IsAny<string>())).Returns(LoadDocument(character));

            var sut = new RbnorwayScraper(htmlMock.Object);

            var expectedInput = "1, 2, 3";
            var expectedHitLevel = "h, h, m";
            var expectedDamage = "7,8,18";
            var expectedStartUp = "10";
            var expectedBlockFrame = "-11";
            var expectedHitFrame = "+5";
            var expectedCounterHitFrame = "FS(+7) 20";
            var expectedNotes = "";

            // Act
            var data = sut.Download(character);
            var actual = data.Moves.FirstOrDefault(m => m.Input == expectedInput);

            //Assert
            Assert.Equal(expectedInput, actual.Input);
            Assert.Equal(expectedHitLevel, actual.HitLevel);
            Assert.Equal(expectedDamage, actual.Damage);
            Assert.Equal(expectedStartUp, actual.StartUp);
            Assert.Equal(expectedBlockFrame, actual.BlockFrame);
            Assert.Equal(expectedHitFrame, actual.HitFrame);
            Assert.Equal(expectedCounterHitFrame, actual.CounterHitFrame);
            Assert.Equal(expectedNotes, actual.Properties);
        }

        [Fact]
        public void Download_CallWithLei_ReturnsCorrectProperties()
        {
            var character = "lei";
            // Arrange
            var htmlMock = new Mock<IHtmlWebWrapper>();
            htmlMock.Setup(doc => doc.GetHtmlDocument(It.IsAny<string>())).Returns(LoadDocument(character));

            var sut = new RbnorwayScraper(htmlMock.Object);

            var expectedInput = "3";
            var expectedHitLevel = "h";
            var expectedDamage = "30";
            var expectedStartUp = "15";
            var expectedBlockFrame = "-9";
            var expectedHitFrame = "-4";
            var expectedCounterHitFrame = "-2";
            var expectedNotes = "Tail spin";

            // Act
            var data = sut.Download(character);
            var actual = data.Moves.FirstOrDefault(m => m.Input == expectedInput);

            //Assert
            Assert.Equal(expectedInput, actual.Input);
            Assert.Equal(expectedHitLevel, actual.HitLevel);
            Assert.Equal(expectedDamage, actual.Damage);
            Assert.Equal(expectedStartUp, actual.StartUp);
            Assert.Equal(expectedBlockFrame, actual.BlockFrame);
            Assert.Equal(expectedHitFrame, actual.HitFrame);
            Assert.Equal(expectedCounterHitFrame, actual.CounterHitFrame);
            Assert.Equal(expectedNotes, actual.Properties);
        }

        [Theory]
        [InlineData("josie")]
        [InlineData("lei")]
        public void Download_CallCharacters_NoNullPropertyObjectsReturned(string character)
        {
            // Arrange
            var htmlMock = new Mock<IHtmlWebWrapper>();
            htmlMock.Setup(doc => doc.GetHtmlDocument((It.IsAny<string>()))).Returns(LoadDocument(character));

            var sut = new RbnorwayScraper(htmlMock.Object);

            // Act
            var moveData = sut.Download(character).Moves;

            //Assert
            Assert.Empty(moveData.Where(m => String.IsNullOrWhiteSpace(m.Input)));
        }

        [Theory]
        [InlineData("josie")]
        [InlineData("lei")]
        public void Download_CallCharacters_NoHeader(string character)
        {
            // Arrange
            var htmlMock = new Mock<IHtmlWebWrapper>();
            htmlMock.Setup(doc => doc.GetHtmlDocument((It.IsAny<string>()))).Returns(LoadDocument(character));

            var sut = new RbnorwayScraper(htmlMock.Object);

            // Act
            var moveData = sut.Download(character).Moves;

            //Assert
            Assert.Empty(moveData.Where(m => m.Input == "Command"));
        }

        [Fact]
        public void Download_CallWithJosie_ReturnsCorrectCount()
        {
            // Arrange
            var htmlMock = new Mock<IHtmlWebWrapper>();
            htmlMock.Setup(doc => doc.GetHtmlDocument((It.IsAny<string>()))).Returns(LoadDocument("josie"));

            var sut = new RbnorwayScraper(htmlMock.Object);

            // Act
            var moveData = sut.Download("josie").Moves;

            //Assert
            Assert.Equal(101, moveData.Count());
        }

        private HtmlDocument LoadDocument(string postfix)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load($"data//mock_rbnorway_{postfix}.html");
            return htmlDoc;
        }
    }
}
