﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoBot.DSA_Game
{
    public class Zauber : Talent
    {
        public Zauber(string name, string probe, int value, char complexity = 'A', string representation = "Magier")
            : base(name, probe, value)
        {
            this.Complexity = complexity;
            this.Representation = this.Representation;
        }

        public char Complexity { get; }

        public string Representation { get; }
    }
}
