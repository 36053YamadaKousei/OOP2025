using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public abstract class ConverterBase {
        // nameで与えられた
        public abstract bool IsMyUnit(string name);
        //メートルとの比率(この比率をかけるとメートルに変換できる)
        protected abstract double Raito { get; }
        //距離の単位名(例えば"メートル"、"フィート"など)
        public abstract string UnitName { get; }
        //メートルからの変換
        public double FromMeter(double meter) => meter / Raito;
        //メートルへの変換
        public double ToMeter(double feet) => feet * Raito;

    }
}
