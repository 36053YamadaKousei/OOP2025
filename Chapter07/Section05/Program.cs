namespace Section05 {
    internal class Program {
        static void Main(string[] args) {
            var text = "The quick brown fox jumps over the lazy dog";
            var words = text.Split(' ');
            var word = words.Where(s => s.Length == 4);

            
        }
    }
}
