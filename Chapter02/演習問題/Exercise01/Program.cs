using System;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //歌データを入れるリストオブジェクトを生成
            var songs = new List<Song>();

            Console.WriteLine("***** 曲の登録 *****");

            while (true) {
                Console.Write("曲名：");
                //入力された曲名を取得
                string title = Console.ReadLine();

                //endが入力されたら登録終了
                if (title.Equals("end", StringComparison.OrdinalIgnoreCase)) break;

                Console.Write("アーティスト名：");
                //入力されたアーティスト名を取得
                string artistname = Console.ReadLine();

                Console.Write("演奏時間（秒）：");
                //入力された演奏時間を取得
                int length = int.Parse(Console.ReadLine());

                //Songインスタンスを生成
                Song song = new Song(title, artistname, length);
                

                //歌データを入れるリストオブジェクトへ登録
                songs.Add(song);

                Console.WriteLine(); //改行
            }

                printSongs(songs);
        }
        //2.1.4
        private static void printSongs(List<Song> songs) {
#if false
            foreach (var song in songs) {
                var minutes = song.Length / 60;
                var secands = song.Length % 60;
                Console.WriteLine($"{song.Title},{song.ArtistName} {minutes}:{secands:00}");
            }
#else
            Console.WriteLine("***** 登録曲一覧 *****");
            //TimeSpan構造体を使った場合
            foreach (var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"{song.Title},{song.ArtistName} {timespan.Minutes}:{timespan.Seconds:00}");
            }
#endif
            Console.WriteLine();
        }
    }
}
