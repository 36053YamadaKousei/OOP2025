using System.Diagnostics;
using System.Threading.Tasks;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async Task button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await DoLongTimeWorkAsync(4000);
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";
        }

        //非同期メソッド
        private async Task DoLongTimeWorkAsync() {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                System.Threading.Thread.Sleep(5000);
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
