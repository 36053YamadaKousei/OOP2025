using System.Configuration;
using System.Data;
using System.Windows;
using System.IO;

namespace CustomerApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application{
    public static string databasePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "customerApp.db"
        );
}

