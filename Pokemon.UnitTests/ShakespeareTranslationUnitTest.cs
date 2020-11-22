using Moq;
using NUnit.Framework;
using Pokemon.Models;
using Pokemon.Services.Classes;
using Pokemon.Services.Interfaces;

namespace Pokemon.UnitTests
{
    public class ShakespeareTranslationUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNoTranslationExistsThrowsException()
        {
            var badDescription = "fake";
            var returnTranslation = new TranslatedObject();
            returnTranslation = null;

            var mockRepo = new Mock<ITranslationRepository>();
            var shakespeareService = new ShakespeareTranslationService(mockRepo.Object);
            mockRepo.Setup(a => a.GetTranslation(badDescription)).Returns(returnTranslation);

            Assert.Throws<ApiException>(() => shakespeareService.GetTranslation(badDescription));
        }

        [Test]
        public void TestApiReturnsSuccessCountOtherThanOneThrowsException()
        {
            var badDescription = "fake";
            var returnTranslation = new TranslatedObject();
            returnTranslation.success = new Success();
            returnTranslation.success.total = 0;
            returnTranslation.contents = new Contents();

            var mockRepo = new Mock<ITranslationRepository>();
            var shakespeareService = new ShakespeareTranslationService(mockRepo.Object);
            mockRepo.Setup(a => a.GetTranslation(badDescription)).Returns(returnTranslation);

            Assert.Throws<ApiException>(() => shakespeareService.GetTranslation(badDescription));
        }
    }
}