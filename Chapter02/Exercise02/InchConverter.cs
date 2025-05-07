using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02{
    class InchConverter{

        //定数
        private const double raito = 39.37;

        //インチからメートルを求める
        public static double FromMeter(double meter) {
            return meter / raito;
        }
        //インチからメートルを求める
        public static double FromInch(double meter) {
            return meter * raito;
        }
    }
}
