using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> rssUrlDict = new Dictionary<string, string>() {
            {"��v","https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
            {"����","https://news.yahoo.co.jp/rss/topics/domestic.xml"},
            {"����","https://news.yahoo.co.jp/rss/topics/world.xml"},
            {"�o��","https://news.yahoo.co.jp/rss/topics/business.xml"},
            {"�G���^��","https://news.yahoo.co.jp/rss/topics/entertainment.xml"},
            {"�X�|�[�c","https://news.yahoo.co.jp/rss/topics/sports.xml"},
            {"IT","https://news.yahoo.co.jp/rss/topics/it.xml"},
            {"�Ȋw","https://news.yahoo.co.jp/rss/topics/science.xml"},
            {"�n��","https://news.yahoo.co.jp/rss/topics/local.xml"}
        };


        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {


                string xml = await hc.GetStringAsync(getRssUrl(cbUrl.Text));
                XDocument xdoc = XDocument.Parse(xml);

                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link"),
                    }).ToList();


                //���X�g�{�b�N�X�փ^�C�g����\��
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "�f�[�^�Ȃ�"));

            }
        }
        //�R���{�{�b�N�X�̕�����m�F����URL�ԋp
        private string getRssUrl(string str) {
            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];
            }
            return str;
        }

        //�^�C�g����I�������Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitles_Click(object sender, EventArgs e) {
            wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
        }

        //�߂�{�^��
        private void btGoBack_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();
        }
        //�i�ރ{�^��
        private void btGoForward_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;
        }

        

        private void Form1_Load(object sender, EventArgs e) {
            cbUrl.DataSource = rssUrlDict.Select(k => k.Key).ToList();

            cbUrl.SelectedIndex = -1;//�N�����ɃR���{�{�b�N�X����

            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;
        }

        private void btRegistration_Click(object sender, EventArgs e) {
            string url = tbFavorite.Text.Trim();
            if (string.IsNullOrEmpty(url)) {
                MessageBox.Show("�o�^����URL����͂��Ă�������");
                return;
            }

            if (cbUrl.Items.Contains(url)) {
                cbUrl.Items.Add(url);
                MessageBox.Show("���C�ɓ���o�^���܂���");
            } else {
                MessageBox.Show("���łɓo�^����Ă��܂�");
            }
        }

        private void btDelete_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedItem == null) {
                MessageBox.Show("�폜����URL��I�����Ă�������");
                return;
            }
            string url = cbUrl.SelectedItem.ToString();
            if (MessageBox.Show($"�u{url}�v���폜���܂����H",
                "�m�F", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                cbUrl.Items.Remove(url);
                if (cbUrl.Items.Count > 0) {
                    cbUrl.SelectedIndex = 0;
                }
            }
        }

        private void lbTitles_DrawItem(object sender, DrawItemEventArgs e) {
            var idx = e.Index;                                                      //�`��Ώۂ̍s
            if (idx == -1) return;                                                  //�͈͊O�Ȃ牽�����Ȃ�
            var sts = e.State;                                                      //�Z���̏��
            var fnt = e.Font;                                                       //�t�H���g
            var _bnd = e.Bounds;                                                    //�`��͈�(�I���W�i��)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);     //�`��͈�(�`��p)
            var txt = (string)lbTitles.Items[idx];                                  //���X�g�{�b�N�X���̕���
            var bsh = new SolidBrush(lbTitles.ForeColor);                           //�����F
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //�I���s��
            var odd = (idx % 2 == 1);                                               //��s��
            var fore = Brushes.WhiteSmoke;                                         //�����s�̔w�i�F
            var bak = Brushes.AliceBlue;                                           //��s�̔w�i�F

            e.DrawBackground();                                                     //�w�i�`��

            //����ڂ̔w�i�F��ς���i�I���s�͏����j
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //������`��
            e.Graphics.DrawString(txt, fnt, bsh, bnd);
        }
    }
}
