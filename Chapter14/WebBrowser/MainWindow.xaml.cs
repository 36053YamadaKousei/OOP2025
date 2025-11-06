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

namespace WebBrowser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window{
    public MainWindow(){
        InitializeComponent();
        InitializeAsync();
    }

    private async void InitializeAsync() {
        await WebView.EnsureCoreWebView2Async();
        WebView.CoreWebView2_NavigationStarting += CoreWebView2_NavigationStarting;
        WebView.CoreWebView2_NavigationCompleted += CoreWebView2_NavigationCompleted;
    }
    //読み込み開始したらプログレスバーを表示


    //読み込み完了したらプログレスバーを非表示



    private void BackButton_Click(object sender, RoutedEventArgs e) {
        if (WebView.CanGoBack) {
            WebView.GoBack;
        }
    }

    private void FowardButton_Click(object sender, RoutedEventArgs e) {
        if (WebView.CanGoFoward) {
            WebView.GoFoward;
        }
    }

    private void GoButton_Click(object sender, RoutedEventArgs e) {
        if (WebView.CanGoFoward) {
            WebView.GoFoward;
        }
    }
}