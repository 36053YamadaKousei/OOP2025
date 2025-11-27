using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TenkiApp.Models;

namespace TenkiApp.Services {
    public class WeatherService {
        private readonly HttpClient _httpClient;

        // コンストラクタ
        public WeatherService() {
            _httpClient = new HttpClient();  // HttpClientのインスタンスを初期化
        }

        // 1週間の天気予報を取得するメソッド
        public async Task<WeeklyWeatherResponse> GetWeeklyWeatherAsync(double lat, double lon) {
            // Open-Meteo APIのURLを作成
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&daily=temperature_2m_max,temperature_2m_min&timezone=Asia/Tokyo";

            // APIからJSONレスポンスを文字列として取得
            var response = await _httpClient.GetStringAsync(url);

            // レスポンス内容をコンソールに出力してJSON形式を確認
            Console.WriteLine(response);  // レスポンスの内容を出力する

            // 取得したレスポンスをWeeklyWeatherResponse型にデシリアライズ
            try {
                var weatherData = JsonSerializer.Deserialize<WeeklyWeatherResponse>(response);
                return weatherData;  // デシリアライズされたデータを返す
            }
            catch (JsonException ex) {
                Console.WriteLine($"デシリアライズエラー: {ex.Message}");
                return null;  // エラーが発生した場合はnullを返す
            }
        }
    }
}
