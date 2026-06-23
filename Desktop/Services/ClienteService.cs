using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Documents;
using Desktop.Models;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using DotNetEnv;


namespace Desktop.Services
{
    public class ClienteService
    {
        
        HttpClient httpClient;
        string urlApi = "https://uzqlmxdcfxlowxhrtecr.supabase.co/rest/v1/clientes";
        public ClienteService()
        {
            Env.Load("../../../");
            var apikey = Environment.GetEnvironmentVariable("apikey_supabase");
            //Instanciamos el httpClient y lo configuramos para utilizarlo en cada uno de los métodos
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi); 
            //agregando url
            //agregamos una ApiKey
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("apikey", apikey);
        }

        public async Task<List<Cliente>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var clientes = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(json);
                    return clientes;
                }
                else
                {
                    MessageBox.Show("Error, no se obtuvo los clientes: " + response.ReasonPhrase);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los clientes: " + ex.Message);
                return null;

            }

        }

        public async Task<List<Cliente>?> GetAllWithFiltersAsync(string filter)
        {
            try
            {
                string filtroSupabase = $"?or=(firstname.ilike.*{filter}*,lastname.ilike.*{filter}*,dni.ilike.*{filter}*,address.ilike.*{filter}*)";
                var response = await httpClient.GetAsync(filtroSupabase);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var clientes = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(json);
                    return clientes;
                }
                else
                {
                    MessageBox.Show("Error, no se obtuvo los clientes: " + response.ReasonPhrase);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los clientes: " + ex.Message);
                return null;

            }

        }

        public async Task<bool> AddClienteAsync(Cliente cliente)

        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                };
                var json = System.Text.Json.JsonSerializer.Serialize(cliente, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al crear el cliente: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el cliente desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> updateClienteAsync(Cliente cliente)

        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                };
                var json = System.Text.Json.JsonSerializer.Serialize(cliente, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //creamos una variable string con el id del cliente para agregarlo a la url
                string urlSelectedId = $"?id=eq.{cliente.id}";
                var response = await httpClient.PutAsync(urlSelectedId, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al actualizar el cliente: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente desde la Api: " + ex.Message);
                return false;
            }
        }
    }
}