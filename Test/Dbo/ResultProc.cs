﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Dbo
{
    public class ResultProc
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        [Column("name_with_underscore")]
        public int NameWithUnderscore { get; set; }
    }
}
