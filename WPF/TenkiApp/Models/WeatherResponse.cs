namespace TenkiApp.Models {
    // 1週間の天気予報のレスポンスを保持するモデル
    public class WeeklyWeatherResponse {
        public DailyWeatherData daily { get; set; }
    }

    // daily オブジェクトのデータ
    public class DailyWeatherData {
        public List<string> time { get; set; }  // 日付のリスト
        public List<double> temperature_2m_max { get; set; }  // 最高気温のリスト
        public List<double> temperature_2m_min { get; set; }  // 最低気温のリスト
    }
}
