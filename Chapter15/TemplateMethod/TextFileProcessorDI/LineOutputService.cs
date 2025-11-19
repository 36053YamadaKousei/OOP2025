using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    //問題15.3
    public class LineOutputService : ITextFileService {
        int _linecount;

        public void Initialize(string fname) {
            _linecount = 0;
        }

        public void Execute(string line) {
            if (_linecount < 20) {
                Console.WriteLine(line);
            }
            _linecount++;
        }

        public void Terminate() {
            Console.WriteLine("出力終了");
        }
    }
}
