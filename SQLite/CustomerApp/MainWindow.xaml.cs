using CustomerApp.Data;
using Microsoft.Win32;
using SQLite;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        OpenFileDialog ofd;

        private List<Customer> _customers = new List<Customer>();
        public MainWindow() {
            InitializeComponent();
            ReadDatabase();

            CustomerListView.ItemsSource = _customers;
        }
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer() {
                

                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text
            };

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabase();
            CustomerListView.ItemsSource = _customers;
        }

        public static byte[] ImageSourceToByteArray(ImageSource imageSource) {
            if (imageSource == null) {
                return null;
            }

            byte[] byteArray = null;
            // MemoryStreamを作成
            using (var stream = new MemoryStream()) {
                // PngEncoderを作成
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imageSource));
                // MemoryStreamにエンコードを保存
                encoder.Save(stream);
                // MemoryStreamの内容をbyte配列として取得
                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        public static BitmapImage byteToBitmap(byte[] bytes) {
            var result = new BitmapImage();

            using (var stream = new MemoryStream(bytes)) {
                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.CreateOptions = BitmapCreateOptions.None;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();    // 非UIスレッドから作成する場合、Freezeしないとメモリリークするため注意
            }
            return result;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer is null) return;

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();

                var customer = new Customer() {
                    Name = NameTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    Address = AddressTextBox.Text
                };

                connection.Update(customer);

                ReadDatabase();
                CustomerListView.ItemsSource = _customers;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("行を選択してください");
                return;
            }

            //データベース接続
            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);    //データベースから選択されているレコードの削除
                ReadDatabase();
                CustomerListView.ItemsSource = _customers;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(p => p.Name.Contains(SearchTextBox.Text));

            CustomerListView.ItemsSource = filterList;
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CustomerListView.SelectedIndex != -1) {
                if (_customers[CustomerListView.SelectedIndex].Picture != null) {
                    CustomerImage.Source = byteToBitmap(_customers[CustomerListView.SelectedIndex].Picture);
                } else {
                    CustomerImage.Source = null;
                }
            }
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer is null) return;
            NameTextBox.Text = selectedCustomer.Name;
            PhoneTextBox.Text = selectedCustomer.Phone;
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e) {
            ofd = new OpenFileDialog();
            if (ofd.ShowDialog() ?? false) {
                CustomerImage.Source = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
            }
        }
    }
}

