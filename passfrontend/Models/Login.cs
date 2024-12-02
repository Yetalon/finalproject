namespace passfrontend.Models{
    /// <summary>
    /// Represents the login information passed to the backend
    /// </summary>
    public class Login{
        /// <summary>
        /// The users username for the login 
        /// </summary>
        public string? LoginUserName {get; set;}
        /// <summary>
        /// The users password for the login 
        /// </summary>
        public string? HashedPassword {get; set;}
    }
}