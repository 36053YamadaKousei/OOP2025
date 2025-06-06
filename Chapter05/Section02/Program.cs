namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            var appVer = new AppVersion(5, 1, 3,125);
            Console.WriteLine(appVer);
        }
    }
    public class AppVersion {
        public int Major { get; init; }
        public int Minor { get; init; }
        public int Build { get; init; }
        public int Revision { get; init; }

        public AppVersion(int major, int minor, int build = 0, int revision = 0) {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }

        public override string ToString() =>
            $"{Major}.{Minor}.{Build}.{Revision}";

    }
}
