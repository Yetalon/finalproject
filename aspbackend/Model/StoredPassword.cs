using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspbackend.model
{
    public class StoredPassword{
        [Key]
        public long Id {get; set;}
        public string ApplicationName {get; set; }
        
        public string ApplicationUsername {get; set; }
        
        public string ApplicationPassword {get; set; }

        public long UserId {get; set; }
    }
}
