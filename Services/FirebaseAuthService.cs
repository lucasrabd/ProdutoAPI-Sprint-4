
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ProdutoAPI.Services
{
    public class FirebaseAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _firebaseApiKey;

        public FirebaseAuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _firebaseApiKey = "YOUR_FIREBASE_API_KEY"; // Substitua pela sua chave Firebase API
        }

        // Método para registrar usuários no Firebase
        public async Task<string> RegisterUser(string email, string password)
        {
            var requestData = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var response = await _httpClient.PostAsJsonAsync($"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={_firebaseApiKey}", requestData);
            var responseData = await response.Content.ReadAsStringAsync();
            var parsedResponse = JObject.Parse(responseData);

            return parsedResponse["idToken"]?.ToString();
        }

        // Método para login de usuários no Firebase
        public async Task<string> LoginUser(string email, string password)
        {
            var requestData = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var response = await _httpClient.PostAsJsonAsync($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={_firebaseApiKey}", requestData);
            var responseData = await response.Content.ReadAsStringAsync();
            var parsedResponse = JObject.Parse(responseData);

            return parsedResponse["idToken"]?.ToString();
        }
    }
}
