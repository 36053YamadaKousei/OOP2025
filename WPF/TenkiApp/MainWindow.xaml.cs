using System;
using System.Linq;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using TenkiApp.Models;
using TenkiApp.Services;
using System.Collections.ObjectModel;

namespace TenkiApp {
    public partial class MainWindow : Window {
        private readonly WeatherService _weatherService;

        // バインド用のプロパティ
        public ObservableCollection<WeatherDay> WeatherDays { get; set; } = new ObservableCollection<WeatherDay>();

        // グラフのデータ
        public ChartValues<double> MaxTemperatures { get; set; }
        public ChartValues<double> MinTemperatures { get; set; }
        public string[] Dates { get; set; }

        public MainWindow() {
            InitializeComponent();
            _weatherService = new WeatherService();  // WeatherServiceのインスタンスを作成
            this.DataContext = this;  // MainWindowのDataContextを自身に設定してバインディングを有効にする
            LoadWeatherDataByCity("東京"); // 初期表示として東京を設定
        }

        // 都市選択時に呼ばれるイベント
        private async void CityComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if (CityComboBox.SelectedItem != null) {
                var selectedCity = ((System.Windows.Controls.ComboBoxItem)CityComboBox.SelectedItem).Content.ToString();
                await LoadWeatherDataByCity(selectedCity);
            }
        }

        // 都市名を選択した場合の天気情報の取得
        private async Task LoadWeatherDataByCity(string cityName) {
            double lat = 0, lon = 0;

            // 都市名に対応する緯度経度を設定
            switch (cityName) {
                case "東京":
                    lat = 35.6895; lon = 139.6917;
                    break;
                case "大阪":
                    lat = 34.0522; lon = 135.7681;
                    break;
                case "名古屋":
                    lat = 35.1815; lon = 136.9066;
                    break;
                case "札幌":
                    lat = 43.0667; lon = 141.3500;
                    break;
                case "福岡":
                    lat = 33.5900; lon = 130.4017;
                    break;
                case "京都":
                    lat = 35.0116; lon = 135.7681;
                    break;
                default:
                    break;
            }

            var weatherData = await _weatherService.GetWeeklyWeatherAsync(lat, lon);

            if (weatherData?.daily != null) {
                var dates = weatherData.daily.time.Select(d => DateTime.Parse(d).ToString("MM/dd")).ToArray();
                var maxTemperatures = weatherData.daily.temperature_2m_max;
                var minTemperatures = weatherData.daily.temperature_2m_min;

                // グラフ用データ
                MaxTemperatures = new ChartValues<double>(maxTemperatures);
                MinTemperatures = new ChartValues<double>(minTemperatures);
                Dates = dates;

                // 表に表示するデータ
                WeatherDays.Clear();
                for (int i = 0; i < weatherData.daily.time.Count; i++) {
                    WeatherDays.Add(new WeatherDay {
                        Date = dates[i],
                        MaxTemperature = maxTemperatures[i],
                        MinTemperature = minTemperatures[i]
                    });
                }

                // グラフにデータを反映
                WeatherChart.Series[0].Values = MaxTemperatures;
                WeatherChart.Series[1].Values = MinTemperatures;
                WeatherChart.AxisX[0].Labels = Dates;

                // 必要に応じてグラフを強制的に再描画
                WeatherChart.InvalidateVisual();
            }
        }
    }

    // 表示用のクラス
    public class WeatherDay {
        public string Date { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }
    }
}
