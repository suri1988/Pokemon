using System;
using Pokemon.Models;
using Pokemon.Services.Interfaces;

namespace Pokemon.Services.Classes
{
    public class ShakespeareTranslationService : ITranslationService
    {
        private ITranslationRepository _translationRepository;
        public ShakespeareTranslationService(ITranslationRepository translationRepository)
        {
            _translationRepository = translationRepository;
        }

        public string GetTranslation(string text)
        {
            var shakespeareTranslation = _translationRepository.GetTranslation(text);
            if (shakespeareTranslation == null)
            {
                throw new ApiException(System.Net.HttpStatusCode.NotFound, "No translation available");
            }
            if (shakespeareTranslation.success.total != 1)
            {
                throw new ApiException(System.Net.HttpStatusCode.NotFound, "No translation available");
            }

            return shakespeareTranslation.contents.translated;
        }
    }
}
