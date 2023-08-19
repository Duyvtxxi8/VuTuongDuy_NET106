using AppClient.IServices;
using AppData.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AppClient.Services
{
    public class ColorService : IColorService
    {
        public readonly HttpClient httpClient;
        public ColorService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Color> AddColor(Color color)
        {
            var response = await httpClient.PostAsJsonAsync("api/color/add-color", color);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Color>(content);
        }

        public async Task DeleteColor(Guid id)
        {
            var response = await httpClient.DeleteAsync($"api/color/delete-color/{id}");
        }

        public async Task<List<Color>> GetAllColors()
        {
            return await httpClient.GetFromJsonAsync<List<Color>>("api/color/get-color");
        }

        public async Task UpdateColor(Guid id)
        {
            var response = await httpClient.PutAsync($"api/color/edit-color/{id}", null);
        }
    }
}
