﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Tg :IFunc
    {
        public float Calc(float x)
        {
            return (float)(Math.Tan(x));
        }
    }
}
