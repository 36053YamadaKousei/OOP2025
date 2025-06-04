
using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);
        }

        private static void Exercise6(string text) {
            Console.WriteLine("出現アルファベットの個数");
            var str = text.ToLower().Replace(" ","");

            //辞書で集計
            var alphDicCount = Enumerable.Range('a', 26)
                .ToDictionary(num => ((char)num).ToString(), num => 0);

            foreach (var alph in str) {
                alphDicCount[alph.ToString()]++;
            }
            foreach (var item in alphDicCount) {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
            Console.WriteLine();

            //配列で集計
            var array = Enumerable.Repeat(0, 26).ToArray();
            foreach(var alph in str) {
                array[alph - 'a']++;
            }
            for (char ch = 'a'; ch < 'z'; ch++) {
                Console.WriteLine($"{ch}:{array[ch - 'a']}");
            }
            Console.WriteLine();

            //'a'から順にカウントして出力
            for (char ch = 'a';ch <= 'z'; ch++) {
                Console.WriteLine($"{ch}:{text.Count(tc => tc == ch)}");
            }
        }

        private static void Exercise1(string text) {
            var spases = text.Count(c => c == ' ');
            Console.WriteLine("空白数:{0}" + spases);

            //var count = text.Count(Char.IsWhiteSpace);  別解
            //Console.WriteLine("空白数:"+count);
        }

        private static void Exercise2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {
            var array = text.Split(' ');
            var sb = new StringBuilder();
            foreach (var word in array) {
                sb.Append(word + " ");
            }
            var str = sb.ToString().TrimEnd();
            Console.WriteLine(sb + ".");
        }

        private static void Exercise4(string text) {
            var count = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}"+count);
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ').Where(s=>s.Length<=4);
            foreach (var word in words) {
                Console.WriteLine(word);
            }
        }
    }
}
