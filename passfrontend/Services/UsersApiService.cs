using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using passfrontend.Models;

namespace passfrontend.Services{
    /// <summary>
    /// Provides functionality for all the api calls in the program to mange users and their applications
    /// </summary>
    public class UsersApiServices{
        /// <summary>
        /// The http client used for making request ot the backend Api
        /// </summary>
        private HttpClient httpClient;
        /// <summary>
        /// initalizes a new instance of <see cref="UsersApiServices"/> and a new instance of <see cref="HttpClient"/>
        /// </summary>
        public UsersApiServices(){
            httpClient = new HttpClient();
        }
        /// <summary>
        /// Sends login information to the API and retrives the associated user.
        /// </summary>
        /// <param name="login">The login information containg the users username and password</param>
        /// <returns>The user assocatied with the login details</returns>
        /// <exception cref="Exception">Thrown if login fails or invaild information is passed through</exception>/// 
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
            throw new Exception("An Error occured while logging in");
        }
        /// <summary>
        /// Retrives a user by their username
        /// </summary>
        /// <param name="userName">The username of the user</param>
        /// <returns>the user with assocatied with that username</returns>
        public async Task<User> GetUserByUserName(string userName){
            var apiResponse = await httpClient.GetFromJsonAsync<User>($"http://localhost:5218/api/Users/username/{userName}");
            return apiResponse;
        }
        /// <summary>
        /// Creates a new user in the database
        /// </summary>
        /// <param name="newuser">the user information to create</param>
        /// <returns>A success message if successful or a Error message otherwise</returns>
        public async Task<string> CreateUser(User newuser){
            var apiResponse = await httpClient.PostAsJsonAsync($"http://localhost:5218/api/Users", newuser);
            if(apiResponse.IsSuccessStatusCode){
                return $"Welcome {newuser.UserName} account creation successful";
            }
            else{
                var Error = await apiResponse.Content.ReadAsStringAsync();
                return $"Error: {Error}";
            }
        }
        /// <summary>
        /// Updates the details of an existing user
        /// </summary>
        /// <param name="id">The user's id</param>
        /// <param name="user">the updated user information</param>
        /// <returns>The user passed in</returns>
        /// <exception cref="Exception">Thrown if the update fails or the user is not found</exception>
        public async Task<User> ChangeUser(long id, User user){
            var apiResponse = await httpClient.PutAsJsonAsync($"http://localhost:5218/api/Users/{id}", user);
            if(apiResponse.IsSuccessStatusCode){
                return user;
            }
            else if(apiResponse.StatusCode == System.Net.HttpStatusCode.BadRequest){
                throw new Exception("User does not match system");
            }
            else if(apiResponse.StatusCode == System.Net.HttpStatusCode.NotFound){
                throw new Exception("User Not found");
            }
            else{
                throw new Exception($"Error: {apiResponse.StatusCode}");
            }
        }
        /// <summary>
        /// Deletes a user from the system
        /// </summary>
        /// <param name="id">The ID of the user to delete</param>
        /// <returns>true if successful and false otherwise</returns>
        public async Task<bool> DeleteUser(long id){
            var apiResponse = await httpClient.DeleteAsync($"http://localhost:5218/api/Users/{id}");
            if(apiResponse.IsSuccessStatusCode){
                return true;
            }
            return false;
        }
        /// <summary>
        /// Creates a new application on the application table
        /// </summary>
        /// <param name="application">the application details to add</param>
        /// <returns>a success message if successful and a Error otherwise</returns>
        public async Task<string> CreateApplication (Application application){
            var apiResponse = await httpClient.PostAsJsonAsync($"http://localhost:5218/api/StoredPasswords", application);
            if(apiResponse.IsSuccessStatusCode){
                return $"{application.ApplicationName} created";
            }
            else{
                var Error = await apiResponse.Content.ReadAsStringAsync();
                return $"Error: {Error}";
            }
        }
        /// <summary>
        /// Retrives a list of all applications assocatied with the user id provided
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns>A list of all applications the user has or a null list if empty</returns>
        public async Task<IEnumerable<Application>> GetApplicationsAsync(long userId){
            var apiResponse = await httpClient.GetFromJsonAsync<IEnumerable<Application>>($"http://localhost:5218/api/StoredPasswords/userid/{userId}");
            if(apiResponse == null){
                return new List<Application>();
            }
            return apiResponse;
        }
        /// <summary>
        /// Deletes an appplication from the database
        /// </summary>
        /// <param name="id">The id of the application to delete</param>
        /// <returns>True if the application was deleted successfully otherwise it throws an exception</returns>
        /// <exception cref="Exception">Thrown if deletion fails</exception> 
        public async Task<bool> DeleteApp(long id){
            var apiResponse = await httpClient.DeleteAsync($"http://localhost:5218/api/StoredPasswords/{id}");
            if(apiResponse.IsSuccessStatusCode){
                return true;
            }
            throw new Exception("Removal failed");
        }
        /// <summary>
        /// Updates teh details of an existing app
        /// </summary>
        /// <param name="id">the id of the application to update</param>
        /// <param name="app">the information for the updated app</param>
        /// <returns>The updated app</returns>
        /// <exception cref="Exception">Thrown if the update fails</exception> 
        public async Task<Application> ChangeApp(long id, Application app){
            var apiResponse = await httpClient.PutAsJsonAsync($"http://localhost:5218/api/StoredPasswords/{id}", app);
            if(apiResponse.IsSuccessStatusCode){
               return app; 
            }
            var Error = await apiResponse.Content.ReadAsStringAsync();
            throw new Exception($"{Error} {apiResponse.StatusCode}");
        }
    }
}