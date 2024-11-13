namespace passfrontend.Models{
    public class Application{
        public long Id {get; set;}
        public string ApplicationName {get; set;}
        public string ApplicationUsername {get; set;}
        public string ApplicationPassword{get; set;}
        public long UserId {get; set;}
    }
}