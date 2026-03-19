using Microsoft.EntityFrameworkCore.Metadata;
using TeenTitansRP;
using static System.Net.WebRequestMethods;

namespace TeenTitansApp.Data
{
    public class TeamService
    {
        private readonly HttpClient _http;
        string errorMsg = "";

        public TeamService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _http.GetFromJsonAsync<List<Team>>("api/Teams/GetTeams");
        }

        public async Task<HttpResponseMessage> AddTeam(Team team)
        {
            return await _http.PostAsJsonAsync("api/Teams/AddTeams", team);
        }

        public async Task DeleteTeam(string name)
        {
            await _http.DeleteAsync($"api/Teams/DeleteTeams?name={name}");
        }
    }
}
