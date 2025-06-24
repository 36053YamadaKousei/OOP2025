namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var today = new DateTime(2025,7,12);//日付
            var now = DateTime.Now;

            
            Console.WriteLine($"Today:{today.Month}");
            Console.WriteLine($"Now:{now}");

            //①自分の生年月日は何曜日をプログラムを書いて調べる
            var birthday = new DateTime(2005,11,2);
            DayOfWeek dayOfWeek = birthday.DayOfWeek;

            Console.WriteLine(dayOfWeek);
        }
    }
}
