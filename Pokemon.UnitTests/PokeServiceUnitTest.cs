using Moq;
using NUnit.Framework;
using Pokemon.Models;
using Pokemon.Services.Classes;
using Pokemon.Services.Interfaces;

namespace Pokemon.UnitTests
{
    public class PokeServiceUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInvalidNamePokeServiceThrowsException()
        {
            var badName = "fake";
            var returnPoke = new RawPokemon();
            returnPoke = null;
            var mockRepo = new Mock<IPokemonRepository>();
            var pokeService = new PokemonService(mockRepo.Object);
            mockRepo.Setup(a => a.GetPokemon(badName)).Returns(returnPoke);

            Assert.Throws<ApiException>(() => pokeService.GetPokemon(badName));
        }

        [Test]
        public void TestMissingCharacteristicPokeServiceThrowsException()
        {
            var name = "test name";
            var returnPoke = new RawPokemon();
            returnPoke.Name = name;
            var pokeCharacteristic = new PokemonCharacteristic();
            pokeCharacteristic = null;
            var mockRepo = new Mock<IPokemonRepository>();
            var pokeService = new PokemonService(mockRepo.Object);
            mockRepo.Setup(a => a.GetPokemon(name)).Returns(returnPoke);
            mockRepo.Setup(a => a.GetCharacteristic(name)).Returns(pokeCharacteristic);
            Assert.Throws<ApiException>(() => pokeService.GetPokemon(name));
        }

        [Test]
        public void TestMissingEnglishDescriptionPokeServiceThrowsException()
        {
            var name = "test name";
            var returnPoke = new RawPokemon();
            returnPoke.Name = name;
            var pokeCharacteristic = new PokemonCharacteristic();
            pokeCharacteristic.descriptions = new System.Collections.Generic.List<Description>();
            pokeCharacteristic.descriptions.Add(new Description { description = "oui francais", language = new Language { name = "fr" } });

            var mockRepo = new Mock<IPokemonRepository>();
            var pokeService = new PokemonService(mockRepo.Object);
            mockRepo.Setup(a => a.GetPokemon(name)).Returns(returnPoke);
            mockRepo.Setup(a => a.GetCharacteristic(name)).Returns(pokeCharacteristic);

            Assert.Throws<ApiException>(() => pokeService.GetPokemon(name));
        }

    }
}