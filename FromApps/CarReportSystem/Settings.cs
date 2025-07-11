using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarReportSystem{
    //設定した色情報を格納
    class Settings{
        [XmlIgnore]
        public int MainFormBackColor { get; set; }
        

    }
}
