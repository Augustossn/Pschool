using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using PschoolCrud.Entities;
using PschoolCrud.Services.Interfaces;

namespace PschoolCrud.Services
{
	public class ClientParentService : IParentService
	{
		private readonly HttpClient _httpClient;

		public ClientParentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Parent> GetById(int id)
		{
			var result = await _httpClient
				.GetFromJsonAsync<Parent>($"/api/parent/{id}");
			return result;
		}

		public async Task<Parent> Post(Parent parent)
		{
			var result = await _httpClient
				.PostAsJsonAsync("/api/parent", parent);
			return await result.Content.ReadFromJsonAsync<Parent>();
		}

		public async Task<Parent> Put(Parent student, int id)
		{
			var result = await _httpClient
				.PutAsJsonAsync($"/api/parent/{id}", student);
			return await result.Content.ReadFromJsonAsync<Parent>();
		}

		public async Task<bool> Delete(int id)
		{
			var result = await _httpClient.DeleteAsync($"/api/parent/{id}");
			return await result.Content.ReadFromJsonAsync<bool>();
		}

		public Task<List<Parent>> GetAll()
		{
			throw new NotImplementedException();
		}
    }
}
