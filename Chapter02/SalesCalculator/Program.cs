namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            SalesCounter sales = new SalesCounter(SalesCounter.ReadSales(@"data\sales.csv"));
            Dictionary<string, int> amountsperStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string,int> obj in amountsperStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");
            }
        }
    }
}
