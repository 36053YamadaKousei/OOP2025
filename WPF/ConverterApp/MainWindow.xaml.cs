using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConverterApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window{



        public MainWindow(){
            InitializeComponent();
            //ComboBoxに単位を追加
            MetricUnit.Items.Add("mm");
            MetricUnit.Items.Add("cm");
            MetricUnit.Items.Add("m");
            MetricUnit.Items.Add("km");

            ImperialUnit.Items.Add("in");
            ImperialUnit.Items.Add("ft");
            ImperialUnit.Items.Add("yd");
            ImperialUnit.Items.Add("ml");
        }

        private void ImperialUnitToMetric_Click(object sender, RoutedEventArgs e) {

        }

        private void MetricToImperialUnit_Click(object sender, RoutedEventArgs e) {

        }
    }
}
