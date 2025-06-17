namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            var abbrs = new Abbreviations();

            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");


            var count = abbrs.Count;
            Console.WriteLine(abbrs.Count);
            Console.WriteLine();


            if (abbrs.Remove("NPI")) {
                Console.WriteLine(abbrs.Count);
            }

            if (abbrs.Remove("NPI")) {
                Console.WriteLine("削除できません");
            }
            Console.WriteLine();

            //8.2.4
            var query = abbrs.Where(x => x.Key.Length == 3);


        }
    }
}
