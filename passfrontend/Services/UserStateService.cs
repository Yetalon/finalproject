using passfrontend.Models;

namespace passfrontend.Services{
    /// <summary>
    /// Manages the state of the currently logged in user
    /// </summary>
    public class UserStateService{
        /// <summary>
        /// The user currently logged in
        /// </summary>
        public User? CurrentUser {get; set;}
        /// <summary>
        /// Indicates whether a user is logged in
        /// </summary>
        public bool LoggedIn {get; set;}
        /// <summary>
        /// Sets teh current user to the user that logged in
        /// </summary>
        /// <param name="user">the user to set to current user</param>
        public void LogIn(User user){
            CurrentUser = user;
        }
        /// <summary>
        /// sets the user to null to log them out
        /// </summary>
        public void LogOut(){
            CurrentUser = null;
        }
        /// <summary>
        /// Checks if the user is null if so sets <see cref="LoggedIn"/> to false other wise is set to true
        /// </summary>
        public void IsUserLoggedIn(){
            if(CurrentUser == null){
                LoggedIn = false;
            }
            else{
                LoggedIn = true;
            }
        }
    }
}