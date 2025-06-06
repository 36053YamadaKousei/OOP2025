﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator{
    //売り上げ集計クラス
    class SalesCounter{
        private readonly List<Sale> _sales;

        //コンストラクタ
        public SalesCounter(string filePath) {
            _sales = ReadSales(filePath);
        }
        //店舗別の売り上げを求める
        public Dictionary<string, int> GetPerStoreSales() {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var sale in _sales) {
                if (dict.ContainsKey(sale.ShopName)) {
                    dict[sale.ShopName] += sale.Amount;
                } else {
                    dict[sale.ShopName] = sale.Amount;
                }
            }
            return dict;
        }
        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        public static List<Sale> ReadSales(string filePath) {
            //売り上げデータを入れるリストオブジェクトを生成
            List<Sale> sales = new List<Sale>();
            //ファイルを一気に読み込み
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines) {
                string[] items = line.Split(',');
                //Saleオブジェクトを生成
                Sale sale = new Sale() {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };
                sales.Add(sale);
            }
            return sales;
        }
    }
}
