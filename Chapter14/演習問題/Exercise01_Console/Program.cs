namespace Exercise01_Console {
    internal class Program {
        static async Task Main(string[] args) {

            string filePath = "吾輩は猫である.txt";

            string fileContent = await ReadTextAsync(filePath);

            Console.WriteLine(fileContent);

        }

        static async Task<string> ReadTextAsync(string filePath) {
            return await File.ReadAllTextAsync(filePath);
        }
    }
}
