using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspbackend.model
{
    /// <summary>
    /// holds the stored passwords for the user's applications
    /// </summary>
    public class StoredPassword{
        /// <summary>
        /// primary key for the app the user created
        /// </summary>
        [Key]
        public long Id {get; set;}
        /// <summary>
        /// The application the stored username and password are used for 
        /// </summary>
        public string ApplicationName {get; set; } 
        /// <summary>
        /// The username used for the app
        /// </summary>
        public string ApplicationUsername {get; set; }
        /// <summary>
        /// the password used for the app
        /// </summary>
        public string ApplicationPassword {get; set; }
        /// <summary>
        /// the user attached to the app
        /// </summary>
        public long UserId {get; set; }
    }
}
