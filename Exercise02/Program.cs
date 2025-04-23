namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("*** 変換アプリ　***");
            Console.WriteLine("１：インチからメートル");
            Console.WriteLine("２：メートルからインチ");

            Console.Write("＞");
            int con = int.Parse(Console.ReadLine());

            Console.Write("はじめ：");
            int start = int.Parse(Console.ReadLine());

            Console.Write("おわり：");
            int end = int.Parse(Console.ReadLine());


            if (con == 1) {
                PrintInchToMeterList(start, end);
            } else {
                PrintMeterToInchList(start, end);
            }
        }
        static void PrintInchToMeterList(int start, int end) {
            //インチからメートルへの対応表を出力
            for (int inch = start; inch <= end; inch++) {
                double meter = InchConverter.FromMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");
            }
        }
        static void PrintMeterToInchList(int start, int end) {
            //メートルからからインチへの対応表を出力
            for (int meter = start; meter <= end; meter++) {
                double inch = InchConverter.FromInch(meter);
                Console.WriteLine($"{meter}m = {inch:0.00}inch");
            }
        }
    }
}

