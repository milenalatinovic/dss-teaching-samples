using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using project.Models;

namespace project.Services
{
    public class ActorService : IActorService
    {
        private readonly HttpClient _httpClient;
        private readonly IMessagingService _messagingService;

        public ActorService(HttpClient httpClient, IMessagingService messagingService)
        {
            _httpClient = httpClient?? throw new ArgumentNullException(
                nameof(httpClient));
            _messagingService = messagingService?? throw new 
                ArgumentNullException(nameof(messagingService));
        }

        public async Task<List<Actor>> GetActors()
        {
            await _messagingService.Add("ActorsService::Actors fetched");
            Actor[] result = await _httpClient.GetFromJsonAsync<Actor[]>(
                "sample-data/actors.json");;
            return new List<Actor>(result);
        }
        
        public async Task<Actor> GetActorById(long id)
        {
            await _messagingService.Add("ActorsService::Actor fetched, with id " + id);
            Actor [] result = await _httpClient.GetFromJsonAsync<Actor[]>(
                "sample-data/actors.json");
            for (int i=0; i<result.Length; i++)
                if(result [i].Id == id)
                    return result [i];
            return null;    
        }
    }
}