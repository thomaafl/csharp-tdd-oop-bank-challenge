﻿using Boolean.CSharp.Main.Acounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Person
    {
        public string Name { get; set; }

        public List<Account> Accounts { get; set; } = new List<Account>();


    }
}
