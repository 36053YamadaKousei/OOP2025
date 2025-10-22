using Microsoft.Win32;
using SQLite;
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

namespace CustomerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window{
    public MainWindow(){
        InitializeComponent();


        OpenFileDialog ofd = new OpenFileDialog();
        var ret = ofd.ShowDialog();
        if (ret ?? false) {

        }
    }

    private void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>();
            _persons = connection.Table<Person>().ToList();
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        var person = new Person() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
        };

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>();
            connection.Insert(person);
        }
    }

    private void ReadButton_Click(object sender, RoutedEventArgs e) {

        ReadDatabase();
        CustomerListView.ItemsSource = _persons;
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
        var item = CustomerListView.SelectedItem as Person;
        if (item == null) {
            MessageBox.Show("行を選択してください");
            return;
        }

        //データベース接続
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>();
            connection.Delete(item);    //データベースから選択されているレコードの削除
            ReadDatabase();
            CustomerListView.ItemsSource = _persons;
        }
    }

    //リストビューのフィルタリング
    private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
        var filterList = _persons.Where(p => p.Name.Contains(SearchTextBox.Text));

        CustomerListView.ItemsSource = filterList;
    }

    //リストビューから１レコード選択
    private void PersonListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var selectedPerson = CustomerListView.SelectedItem as Person;
        if (selectedPerson is null) return;
        NameTextBox.Text = selectedPerson.Name;
        PhoneTextBox.Text = selectedPerson.Phone;
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e) {
        var selectedPerson = CustomerListView.SelectedItem as Person;
        if (selectedPerson is null) return;

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>();

            var person = new Person() {
                Id = selectedPerson.Id,
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
            };

            connection.Update(person);

            ReadDatabase();
            CustomerListView.ItemsSource = _persons;
        }
    }
}