
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books
                .MaxBy(b => b.Price);
            Console.WriteLine(max);
        }

        private static void Exercise1_3() {
            
        }

        private static void Exercise1_4() {
            //P299を参照
            var books = Library.Books.OrderByDescending(x => x.PublishedYear).ThenByDescending(x => x.Price);
            foreach (var item in books) {
                Console.WriteLine($"{item.PublishedYear}年{item.Price}円{item.Title}");
            }
        }

        private static void Exercise1_5() {
            var categoryNames = Library.Books
                .Where(b => b.PublishedYear == 2022)
                .Join(Library.Categories,
                    b => b.CategoryId,
                    c => c.Id,
                    (b, c) => new { c.Name })
                .Distinct();
            foreach (var name in categoryNames) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise1_6() {
            var groups = Library.Books
                .Join(Library.Categories,
                    b => b.CategoryId,
                    c => c.Id,
                    (b, c) => new {
                        CategoryName = c.Name,
                        b.Title
                    })
                .GroupBy(x => x.CategoryName)
                .OrderBy(x => x.Key);

            foreach (var group in groups) {
                Console.WriteLine($"#{group.Key}");
                foreach (var book in group) {
                    Console.WriteLine($"{book.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            var groups = Library.Categories
                .Where(x => x.Name.Equals("Development"))
                .Join(Library.Books,
                    c => c.Id,
                    b => b.CategoryId,
                    (c, b) => new {
                        b.Title,
                        b.PublishedYear
                    })
                .GroupBy(x => x.PublishedYear)
                .OrderBy(x => x.Key);

            foreach (var group in groups) {
                Console.WriteLine($"#{group.Key}");
                foreach (var book in group) {
                    Console.WriteLine($"{book.Title}");
                }
            }
        }

        private static void Exercise1_8() {
            var groups = Library.Categories
                .GroupJoin(Library.Books,
                    c => c.Id,
                    b => b.PublishedYear,
                    (c, books) => new {
                        Categories = c.Name,
                        Books = books,
                    });
            
        }
    }
}
