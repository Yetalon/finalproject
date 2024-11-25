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
                if(userResponse != null){
                    return userResponse;
                }
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
        public async Task<User> ChangeUser(long id, User user){
            var apiResponse = await httpClient.PutAsJsonAsync($"http://localhost:5218/api/Users/{id}", user);
            if(apiResponse.IsSuccessStatusCode){
                return user;
            }
            else if(apiResponse.StatusCode == System.Net.HttpStatusCode.BadRequest){
                throw new Exception("user does not match system");
            }
            else if(apiResponse.StatusCode == System.Net.HttpStatusCode.NotFound){
                throw new Exception("User Not found");
            }
            else{
                throw new Exception($"error: {apiResponse.StatusCode}");
            }
        }
        public async Task<bool> DeleteUser(long id){
            var apiResponse = await httpClient.DeleteAsync($"http://localhost:5218/api/Users/{id}");
            if(apiResponse.IsSuccessStatusCode){
                return true;
            }
            return false;
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
            var apiResponse = await httpClient.GetFromJsonAsync<IEnumerable<Application>>($"http://localhost:5218/api/StoredPasswords/userid/{userId}");
            if(apiResponse == null){
                return new List<Application>();
            }
            return apiResponse;
        }
        public async Task<bool> DeleteApp(long id){
            var apiResponse = await httpClient.DeleteAsync($"http://localhost:5218/api/StoredPasswords/{id}");
            if(apiResponse.IsSuccessStatusCode){
                return true;
            }
            throw new Exception("Removal failed");
        }
        public async Task<Application> ChangeApp(long id, Application app){
            var apiResponse = await httpClient.PutAsJsonAsync($"http://localhost:5218/api/StoredPasswords/{id}", app);
            if(apiResponse.IsSuccessStatusCode){
               return app; 
            }
            var error = await apiResponse.Content.ReadAsStringAsync();
            throw new Exception($"{error} {apiResponse.StatusCode}");
        }
    }
}