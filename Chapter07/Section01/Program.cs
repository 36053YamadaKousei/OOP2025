namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var books = Books.GetBooks();

            //①本の平均金額を表示
            Console.WriteLine((int)books.Average(x => x.Price));

            //②本のページ合計を表示
            Console.WriteLine(books.Sum(x => x.Pages));

            //③金額の安い書籍名と金額を表示

            Console.WriteLine(books.Min(x => x.Price));

            //④ページが多い書籍名とページ数を表示
            Console.WriteLine(books.Max(x => x.Pages));

            //⑤タイトルに「物語」が含まれている書籍名をすべて表示


        }
    }
}
