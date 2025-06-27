using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            
            var now = DateTime.Now;

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
            var dateOfBirth = new DateTime(year,month,day);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = dateOfBirth.ToString("ggyy年M月d日", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateOfBirth.DayOfWeek);

            Console.WriteLine($"{str}は{dayOfWeek}です");

            //③生まれてから○○○○日目です
            TimeSpan diff = now - dateOfBirth;
            Console.WriteLine($"生まれてから{diff.Days}日目です");

            //④あなたは○○歳です！
            int age = GetAge(dateOfBirth, DateTime.Today);
            Console.WriteLine(age + "歳");


            //⑤１月１日から何日目か？
            var today = DateTime.Today;
            int dayOfYear = today.DayOfYear;
            Console.WriteLine(dayOfYear);

            //②うるう年の判定プログラムを作成する
            Console.Write("西暦：");
            var leapyear = int.Parse(Console.ReadLine());
            var isLeapYear = DateTime.IsLeapYear(leapyear);

            if (isLeapYear) {
                Console.WriteLine("閏年です");
            } else {
                Console.WriteLine("閏年ではありません");
            }
        }
        static int GetAge(DateTime dateOfBirth,DateTime targetDay) {

        }
    }
}
