namespace passfrontend.Models{
    /// <summary>
    /// Represents an application for the user to store their logins
    /// </summary>
    public class Application{
        /// <summary>
        /// Primary key for the application table
        /// </summary>
        public long Id {get; set;}
        /// <summary>
        /// Users application name 
        /// </summary>
        public string ApplicationName {get; set;}
        /// <summary>
        /// Users application username 
        /// </summary>
        public string ApplicationUsername {get; set;}
        /// <summary>
        /// users application password 
        /// </summary>
        public string ApplicationPassword{get; set;}
        /// <summary>
        /// Users ID attached to the application 
        /// </summary>
        public long UserId {get; set;}
    }
}