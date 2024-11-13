using passfrontend.Models;

namespace passfrontend.Services{
    public class UserStateService{
        public User? CurrentUser {get; set;}
        public bool LoggedIn {get; set;}
        public void LogIn(User user){
            CurrentUser = user;
        }
        public void LogOut(){
            CurrentUser = null;
        }
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