using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var employees = Deserialize("employees.json");
            ToXmlFile(employees);
        }

        static Employee[] Deserialize(string filePath) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            var text = File.ReadAllText(filePath);
            var employees = JsonSerializer.Deserialize<Employee[]>(text, options);
            return employees ?? [];
        }

        static void ToXmlFile(Employee[] employees) {


        }
    }

    public record Employee {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }
    }
}
