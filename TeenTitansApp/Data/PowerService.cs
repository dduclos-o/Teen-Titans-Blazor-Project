using TeenTitansRP;

namespace TeenTitansApp.Data
{
    public class PowerService
    {
        private readonly HttpClient _http;
        string errorMsg = "";

        public PowerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Power>> GetPowers()
        {
            return await _http.GetFromJsonAsync<List<Power>>("api/Powers/GetPowers");
        }

        public async Task<HttpResponseMessage> AddPower(Power power)
        {
            return await _http.PostAsJsonAsync("api/Powers/AddPowers", power);
        }

        public async Task DeletePower(string name)
        {
            await _http.DeleteAsync($"api/Powers/DeletePowers?name={name}");
        }
    }
}
