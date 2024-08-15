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
	public class ClientStudentService : IStudentService
	{
		private readonly HttpClient _httpClient;

		public ClientStudentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

        public async Task<List<Student>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Student>>("api/students");
        }

        public async Task<Student> GetById(int id)
		{
			var result = await _httpClient
				.GetFromJsonAsync<Student>($"/api/student/{id}");
			return result;
		}

		public async Task<Student> Post(Student student)
		{
			var result = await _httpClient
				.PostAsJsonAsync("/api/student", student);
			return await result.Content.ReadFromJsonAsync<Student>();
		}

		public async Task<Student> Put(Student student, int id)
		{
			var result = await _httpClient
				.PutAsJsonAsync($"/api/student/{id}", student);
			return await result.Content.ReadFromJsonAsync<Student>();
		}

		public async Task<bool> Delete(int id)
		{
			var result = await _httpClient.DeleteAsync($"/api/student/{id}");
			return await result.Content.ReadFromJsonAsync<bool>();
		}

		public async Task<List<Parent>> GetAllParents()
		{
            return await _httpClient.GetFromJsonAsync<List<Parent>>("api/parents");
        }
	}
}
