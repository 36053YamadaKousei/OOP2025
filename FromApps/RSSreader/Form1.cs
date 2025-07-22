using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> rssUrlDict = new Dictionary<string, string>() {
            {"主要","https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
            {"国内","https://news.yahoo.co.jp/rss/topics/domestic.xml"},
            {"国際","https://news.yahoo.co.jp/rss/topics/world.xml"},
            {"経済","https://news.yahoo.co.jp/rss/topics/business.xml"},
            {"エンタメ","https://news.yahoo.co.jp/rss/topics/entertainment.xml"},
            {"スポーツ","https://news.yahoo.co.jp/rss/topics/sports.xml"},
            {"IT","https://news.yahoo.co.jp/rss/topics/it.xml"},
            {"科学","https://news.yahoo.co.jp/rss/topics/science.xml"},
            {"地域","https://news.yahoo.co.jp/rss/topics/local.xml"}
        };

        


        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {


                string xml = await hc.GetStringAsync(getRssUrl(cbUrl.Text));
                XDocument xdoc = XDocument.Parse(xml);

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link"),
                    }).ToList();


                //リストボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "データなし"));

            }
        }
        //コンボボックスの文字列確認してURL返却
        private string getRssUrl(string str) {
            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];
            }
            return str;
        }

        private void lbTitles_Click(object sender, EventArgs e) {
            wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
        }

        //戻るボタン
        private void btGoBack_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();
        }
        //進むボタン
        private void btGoForward_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;
        }

        private void Form1_Load(object sender, EventArgs e) {
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();

            
        }
    }
}
