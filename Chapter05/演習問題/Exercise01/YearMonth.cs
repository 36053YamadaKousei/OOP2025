using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01{
    //5.1.1
    public class YearMonth{
        public int GiveYear { get; init; }
        public int GiveMonth { get; init; }

        public YearMonth(int giveYear, int giveMonth) {
            GiveYear = giveYear;
            GiveMonth = giveMonth;
        }
        //5.1.2
        //設定されている西暦が２１世紀か判定する
        //Yearが2001～2100年の間ならtrue、それ以外ならfalseを返す
        public bool Is21Century => 2001 <= GiveYear && GiveYear <= 2100;　//getを使って考える


        //5.1.3
        public YearMonth AddOneMonth() {

        }

        //5.1.4
    }
}
