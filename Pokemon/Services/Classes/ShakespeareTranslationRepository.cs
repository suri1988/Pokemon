using System;
using Pokemon.Models;
using Pokemon.Services.Interfaces;
using RestSharp;

namespace Pokemon.Services.Classes
{
    public class ShakespeareTranslationRepository : ITranslationRepository
    {
        public TranslatedObject GetTranslation(string text)
        {
            var client = new RestClient("https://api.funtranslations.com/translate/shakespeare.json");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { text = text });
            var response = client.Execute<TranslatedObject>(request);

            return response.Data;
        }
    }
}
