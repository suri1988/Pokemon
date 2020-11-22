using System;
using Pokemon.Models;

namespace Pokemon.Services.Interfaces
{
    public interface ITranslationRepository
    {
        public TranslatedObject GetTranslation(string text);
    }
}
