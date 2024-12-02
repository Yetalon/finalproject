namespace aspbackend.model{
    /// <summary>
    /// Holds the username and in the future the hashedpassword of the user 
    /// used for a post request for logging in
    /// </summary>
    public class Login{
        /// <summary>
        /// User's username
        /// </summary>
        public string LoginUserName {get; set;}
        /// <summary>
        /// User's password
        /// </summary>
        public string HashedPassword {get; set;}
    }
}