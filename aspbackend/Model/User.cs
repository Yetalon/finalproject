using System.ComponentModel.DataAnnotations;

namespace aspbackend.model{
    /// <summary>
    /// User information stored in the database
    /// </summary>
    public class User{
        /// <summary>
        /// primary key for the user table that automatically increments
        /// </summary>
        [Key]
        public long Id {get; set;}
        /// <summary>
        /// Username the user choose
        /// </summary>
        public string? UserName {get; set;}
        /// <summary>
        /// User's master password
        /// </summary>
        public string? Password {get; set;}
    }
}