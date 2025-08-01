﻿

namespace Test02 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new[] { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin",
                "Canberra", "Hong Kong",
            };

            #region テスト用ドライバ
            Console.WriteLine("問題１：合計値");
            Exercise01(numbers);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題２：奇数の最大値");
            Exercise02(numbers);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題３：昇順");
            Exercise03(numbers);
            Console.WriteLine("\n\n-----");

            Console.WriteLine("問題４：10 以上 50 以下のみ");
            Exercise04(numbers);
            Console.WriteLine("\n\n-----");

            Console.WriteLine("問題５：小文字の'n'が含まれている都市数");
            Exercise05(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題６：全都市数");
            Exercise06(cities);
            Console.WriteLine("\n-----");

            #endregion
        }


        //---------------------------------------
        // 以下の問題に書かれている内容を満たすようにプログラムを作成せよ。
        // 必要であればラムダ式とLINQを使用すること
        //---------------------------------------

        //問題１　平均値を表示（式形式で記述せよ）
        private static void Exercise01(int[] numbers) => Console.WriteLine(numbers.Average());


        //問題２　奇数の最大値を表示（式形式で記述せよ）
        //　　　　出力結果【91】
        private static void Exercise02(int[] numbers) => Console.WriteLine(numbers.Where(n => n % 2 == 1).Max());


        //問題３　降順に並べて表示（遅延実行とする）
        //　　　　出力結果【12 14 17 20 31 35 40 48 53 76 87 91 94】←この逆順
        private static void Exercise03(int[] numbers) {
            var num = numbers.OrderByDescending(n => n);
            foreach (var item in num) {
                Console.Write(item + " ");
            }
        }

        //問題４　30以上40未満の数字のみを表示（即時実行でも可とする）
        //　　　　出力結果【40 35 31 48】
        private static void Exercise04(int[] numbers) {
            var num = numbers.Where(n => n >= 30 && 40 > n);
            foreach (var item in num) {
                Console.Write(item + " ");
            }
        }

        //問題５　Countメソッドを使い、小文字の'f'が含まれている都市名がいくつあるかカウントして結果を表示
        //　　　　出力結果【5】
        private static void Exercise05(List<string> cities) {
            Console.WriteLine(cities.Count(s => s.Contains('f')));

        }

        //問題６　全都市数
        //　　　　出力結果【8】
        private static void Exercise06(List<string> cities) {
            Console.WriteLine(cities.Count);
        }

    }
}
