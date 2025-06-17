namespace Test01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = (IEnumerable<Student>?)ReadScore(filePath);
        }

        //メソッドの概要： 
        private static Dictionary<string,int> ReadScore(string filePath) {
            



        }

        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {
            IDictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Student score in _score) {
                if (dict.ContainsKey(score.Name)) {
                    dict[score.Name] += score.Score;
                } else {
                    dict[score.Name] = score.Score;
                }
            }
            return dict;
        }
    }
}
