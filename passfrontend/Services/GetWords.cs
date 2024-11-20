namespace passfrontend.Services{
    public class GetWords{
        public List<string> AllWords {get; set;}
        public GetWords(){
            AllWords = new();
        }
        public void FillAllWords(){
            using(StreamReader reader = new StreamReader("words.txt")){
                while(!reader.EndOfStream){
                    string word = reader.ReadLine();
                    AllWords.Add(word);
                }
            }
        }
    }
}