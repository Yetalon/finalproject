namespace passfrontend.Services{
    /// <summary>
    /// Manages a list of words for passphrase generation 
    /// </summary>
    public class GetWords{
        /// <summary>
        /// a list of 20,000 words
        /// </summary>
        public List<string> AllWords {get; set;}
        /// <summary>
        /// initalizes a new instance of <see cref="GetWords"/> and Creates a empty list of <see cref="AllWords"/>
        /// </summary>
        public GetWords(){
            AllWords = new();
        }
        /// <summary>
        /// fills the list of allwords with 20,000 words from a text file
        /// </summary>
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