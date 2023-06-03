﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace Lab4.Domain.Controllers
{
    [Route("api/Domain/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _client;

        public ServiceController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Service[]>> GetServices()
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Services");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Service[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Service>();
        }
/*
        [HttpGet("{id}")]
        public async Task<ActionResult<Client?>> GetClient(int id)
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Client/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Client?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        
        [HttpPost]
        public async Task<Client?> PostClient(Client newClient)
        {
            JsonContent content = JsonContent.Create(newClient);
            var response = await _client.PostAsync($"{_DalConnectionString}/api/Client", content);
            response.EnsureSuccessStatusCode();
            Client? person = await response.Content.ReadFromJsonAsync<Client>();

            return person;
        }

        [HttpDelete("{id}")]
        public async Task DeleteClient(int id)
        {
            var response = await _client.DeleteAsync($"{_DalConnectionString}/api/Client/DeleteClient/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutClient(Client newClient)
        {
            JsonContent content = JsonContent.Create(newClient);
            var response = await _client.PutAsync($"{_DalConnectionString}/api/Client/PutClient", content);
            response.EnsureSuccessStatusCode();
        }*/
    }
}
