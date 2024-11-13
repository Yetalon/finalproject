using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using passfrontend.Models;

namespace passfrontend.Services{
    public class UsersApiServices{
        private HttpClient httpClient;
        public UsersApiServices(){
            httpClient = new HttpClient();
        }
        public async Task<User> GetUser(Login login){
            var apiResponse = await httpClient.PostAsJsonAsync($"http://localhost:5218/api/Users/login", login);
            if(apiResponse.IsSuccessStatusCode){
                var userResponse = await apiResponse.Content.ReadFromJsonAsync<User>();
                return userResponse;
            }
            else if(apiResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized){
                throw new Exception("Invalid username or password");
            }
            else if(apiResponse.StatusCode == System.Net.HttpStatusCode.NotFound){
                throw new Exception("User does not exist");
            }
            throw new Exception("An error occured while logging in");
        }
        public async Task<User> GetUserByUserName(string userName){
            var apiResponse = await httpClient.GetFromJsonAsync<User>($"http://localhost:5218/api/Users/username/{userName}");
            if(apiResponse == null){
                throw new Exception("Invalid user");
            }
            return apiResponse;
        }
        public async Task<string> CreateUser(User newuser){
            var apiResponse = await httpClient.PostAsJsonAsync($"http://localhost:5218/api/Users", newuser);
            if(apiResponse.IsSuccessStatusCode){
                return $"Welcome {newuser.UserName} account creation successful";
            }
            else{
                var error = await apiResponse.Content.ReadAsStringAsync();
                return $"oopsie doopsie error: {error}";
            }
        }

        public async Task<string> CreateApplication (Application application){
            var apiResponse = await httpClient.PostAsJsonAsync($"http://localhost:5218/api/StoredPasswords", application);
            if(apiResponse.IsSuccessStatusCode){
                return $"{application.ApplicationName} created";
            }
            else{
                var error = await apiResponse.Content.ReadAsStringAsync();
                return $"oopsie doopsie error: {error}";
            }
        }
        public async Task<IEnumerable<Application>> GetApplicationsAsync(long userId){
            var apiResponse = await httpClient.GetFromJsonAsync<IEnumerable<Application>>($"http://localhost:5218/api/userid/{userId}");
            if(apiResponse == null){
                return new List<Application>();
            }
            return apiResponse;
        }
    }
}