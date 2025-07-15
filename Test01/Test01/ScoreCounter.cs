namespace Test01 {
    public class ScoreCounter {
        private readonly IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要： 生徒のスコアを読み込み、Studentオブジェクトのリストを返す
        private static IEnumerable<Student> ReadScore(string filePath) {
            var scores = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                var items = line.Split(',');
                Student student = new Student() {
                    Name = items[1],
                    Subject = items[2],
                    Score = int.Parse(items[2])
                };
                scores.Add(student);
            }
        }

        //メソッドの概要： 生徒別にスコアを求める
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var score in _score) {
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
