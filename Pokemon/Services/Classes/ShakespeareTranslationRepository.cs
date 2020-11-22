using System;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Pokemon.Models;
using Pokemon.Services.Interfaces;
using RestSharp;

namespace Pokemon.Services.Classes
{
    public class ShakespeareTranslationRepository : ITranslationRepository
    {
        private readonly IConfiguration _configuration;

        public ShakespeareTranslationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TranslatedObject GetTranslation(string text)
        {
            int retryMax = 5;
            int count = 0;

            var client = new RestClient(_configuration["ApiSettings:shakespeareApiUrl"]);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { text = text });
            var response = client.Execute<TranslatedObject>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                while (count <= retryMax && response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    count++;
                    Thread.Sleep((count ^ 2) * 1000); 
                    response = client.Execute<TranslatedObject>(request);
                }
            }

            return response.Data;
        }
    }
}
