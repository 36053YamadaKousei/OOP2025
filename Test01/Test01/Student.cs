﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01 {
    public class Student {
        //プロパティ
        public required string Name { get; init; } = string.Empty;//学生の名前
        public required string Subject { get; init; } = string.Empty;//科目名
        public required int Score { get; init; } //点数

    }
}
