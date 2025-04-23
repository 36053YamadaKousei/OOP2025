namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            PrintInchToMeterList(1, 10);
        }
        static void PrintInchToMeterList(int start,int end) {
            //インチからメートルへの対応表を出力
            for (int inch = start; inch <= end; inch++) {
                double meter = InchConverter.FromMeter(inch);
                Console.WriteLine($"{inch}inch = {meter:0.0000}m");
            }
        }
    }
}

