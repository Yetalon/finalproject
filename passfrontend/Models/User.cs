namespace passfrontend.Models{
    /// <summary>
    /// Represents the user and their information
    /// </summary>
    public class User{
        /// <summary>
        /// Primary key for the user table
        /// </summary>
        public long Id {get; set;}
        /// <summary>
        /// the username for the user
        /// </summary>
        public string? UserName {get; set;}
        /// <summary>
        /// the password for the user
        /// </summary>
        public string? Password {get; set;}
    }
}