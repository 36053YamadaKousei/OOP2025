using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ColorChecker
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window{

        Color loadColor = Color.FromRgb(0, 0, 0);//起動時の色
        //MyColor currentColor; //現在設定している色情報

        public MainWindow(){
            InitializeComponent();
            DataContext = GetColorList();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        //すべてのスライダーから呼ばれるイベントハンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            //colorAreaの背景色はスライダーで指定されたRGBの色を表示
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            Color color = Color.FromRgb(r, g, b);
            Brush brush = new SolidColorBrush(color);
            colorArea.Background = brush;
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;
            Color selectedColor = Color.FromRgb(r, g, b);



            // すでにストックされている色を確認
            if (IsColorAlreadyStocked(selectedColor)) {
                MessageBox.Show("既に登録されています。", "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;  // 色がすでに登録されている場合は何もしない
            }
            //色のプレビュー（視覚的にわかりやすくするため）
            Border colorPreview = new Border {
                Width = 30,
                Height = 20,
                Background = new SolidColorBrush(selectedColor),
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Margin = new Thickness(5, 0, 5, 0)
            };
            //RGBの値のテキスト
            TextBlock rgbText = new TextBlock {
                Text = $"R:{r} G:{g} B:{b}",
                VerticalAlignment = VerticalAlignment.Center
            };
            StackPanel panel = new StackPanel {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(2)
            };
            panel.Children.Add(colorPreview);
            panel.Children.Add(rgbText);
            //作成して中に入れる
            ListBoxItem item = new ListBoxItem {
                Content = panel
            };
            //追加
            colorStockListBox.Items.Add(item);
        }
        //色がすでに登録されているか確認するメソッド
        private bool IsColorAlreadyStocked(Color color) {
            foreach (ListBoxItem item in colorStockListBox.Items) {
                var panel = item.Content as StackPanel;
                if (panel != null) {
                    var colorPreview = panel.Children[0] as Border;
                    if (colorPreview != null) {
                        Color existingColor = ((SolidColorBrush)colorPreview.Background).Color;
                        if (existingColor == color) {
                            return true; // 色がすでに登録されている場合
                        }
                    }
                }
            }
            return false; // 色が登録されていない場合
        }

        //コンボボックスから色を選択
        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var comboSelectMyColor = (MyColor)((ComboBox)sender).SelectedItem;

            //currentColor == comboSelectMyColor;
            setSliderValue(comboSelectMyColor.Color); //スライダー設定
        }

        //各スライダーの値を設定する
        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void colorStockListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // 選択された色を取得
            if (colorStockListBox.SelectedItem is ListBoxItem selectedItem) {
                //色の表示部分を取得
                var panel = selectedItem.Content as StackPanel;
                if (panel != null) {
                    //色のプレビューであることを仮定
                    var colorPreview = panel.Children[0] as Border;
                    if (colorPreview != null) {
                        //背景色を取得、それに対応するRGBの値を設定
                        Color selectedColor = ((SolidColorBrush)colorPreview.Background).Color;

                        //スライダーにそのRGBの値を設定
                        setSliderValue(selectedColor);

                        //colorArea の背景色を更新
                        colorArea.Background = new SolidColorBrush(selectedColor);
                    }
                }
            }
        }
        //Windowが表示されるタイミングで呼ばれる
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            colorSelectComboBox.SelectedIndex = GetColorToIndex(loadColor);
        }
        //色情報から色配列のインデックスを取得する
        private int GetColorToIndex(Color color) {
            return ((MyColor[])DataContext).ToList().FindIndex(c => c.Color.Equals(color));
        }
    }
}
