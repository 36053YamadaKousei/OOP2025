namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            var appVer = new AppVersion(5, 1, 3);
            Console.WriteLine(appVer);
        }
    }
    public class AppVersion(int m, int mi, int b = 0, int r = 0) {
        public int Major { get; init; } = m;
        public int Minor { get; init; } = mi;
        public int Build { get; init; } = b;
        public int Revision { get; init; } = r;

        public override string ToString() =>
            $"{Major}.{Minor}.{Build}.{Revision}";

    }
}
