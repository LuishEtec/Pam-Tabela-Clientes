
using ClienteCrudApp.Models;
using System.Text;
using System.Text.Json;

namespace ClienteCrudApp.Services
{
    public class ClienteService
    {
        public string? LastErrorMessage { get; private set; }
        HttpClient _httpClient;
        string baseUrl = "https://clienteapi-haa3cvevhzd3e4bz.brazilsouth-01.azurewebsites.net/api/cliente";

        public ClienteService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            var response = await _httpClient.GetStringAsync(baseUrl);
            return JsonSerializer.Deserialize<List<Cliente>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> AddClienteAsync(Cliente cliente)
        {
            LastErrorMessage = null;

            var json = JsonSerializer.Serialize(cliente);
            var response = await _httpClient.PostAsync(baseUrl, new StringContent(json, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                LastErrorMessage = await response.Content.ReadAsStringAsync();
            }

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            var json = JsonSerializer.Serialize(cliente);
            var url = $"{baseUrl}/{cliente.id_cliente}";
            var response = await _httpClient.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            var url = $"{baseUrl}/{id}";
            var response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }

        public async Task<Cliente> LoginClienteAsync(string email, string senha)
        {
            var clientes = await GetClientesAsync();
            return clientes.FirstOrDefault(c => c.EmailCliente == email && c.SenhaCliente == senha);
        }
    }
}
