using TeenTitansRP;

namespace TeenTitansApp.Data
{

    public class CharacterService
    {
        private readonly HttpClient _http;

        public CharacterService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Character>> GetCharacters()
        {
            return await _http.GetFromJsonAsync<List<Character>>("api/Characters/GetCharacters");
        }

        public async Task<HttpResponseMessage> AddCharacter(Character character)
        {
            return await _http.PostAsJsonAsync("api/Characters/AddCharacters", character);
        }

        public async Task DeleteCharacter(string name)
        {
            await _http.DeleteAsync($"api/Characters/DeleteCharacters?name={name}");
        }
    }
}
