using System.Text.RegularExpressions;

namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            var strings = new[] {
                "Microsofft Windows",
                "windows",
                "Windows Server",
                "Windows"
            };

            var regex = new Regex(@"^(W|w)indows$");

            //パターンと完全一致している文字列の個数をカウント
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine($"{count}行と一致");

            //パターンと完全一致している文字列を出力する
            //var datas = strings.Where(s => regex.IsMatch(s));
            //foreach (var item in datas) {
            //    Console.WriteLine(item);
            //}

            strings.Where(s => regex.IsMatch(s)).ToList().ForEach(Console.WriteLine);

        }
    }
}
