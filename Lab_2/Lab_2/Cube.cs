﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Cube: IFunc
    {
        public float Calc(float x)
        {
            return (float)(x * x * x);
        }
    }
}
