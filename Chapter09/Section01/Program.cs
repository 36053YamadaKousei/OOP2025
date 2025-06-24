using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var today = new DateTime(2025,7,12);//日付
            var now = DateTime.Now;

            
            Console.WriteLine($"Today:{today.Month}");
            Console.WriteLine($"Now:{now}");

            //①自分の生年月日は何曜日をプログラムを書いて調べる
            //var dateOfBirth = new DateTime(2005,11,2);
            //DayOfWeek dayOfWeek = dateOfBirth.DayOfWeek;
            //Console.WriteLine(dayOfWeek);

            Console.Write("西暦：");
            var year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            var day = int.Parse(Console.ReadLine());

            //平成○○年○月○日は○曜日です　←曜日は漢字で（P202）
            var date = new DateTime(year,month,day);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = date.ToString("ggyy年M月d日", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            Console.WriteLine($"{str}は{dayOfWeek}");
            

            //②うるう年の判定プログラムを作成する
            
        }
    }
}
