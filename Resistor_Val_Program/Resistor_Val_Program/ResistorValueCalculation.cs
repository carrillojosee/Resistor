﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistorNamespace
{
    public class ResistorValueCalculation
    {
        //num of bands
        //make an enum?of all of the colors 
        //make multiplier constant
        // tolerance in percent
        //
        enum bandValueColors
        {
            black = 0,
            brown = 1,
            red = 2,
            orange = 3,
            yellow = 4,
            green = 5,
            blue = 6,
            violet = 7,
            grey = 8,
            white = 9
        }
        enum multiplierColor
        {
            black =  1,
            brown =  10,
            red =    100,
            orange = 1000,
            yellow = 10000,
            green =  100000,
            blue =   1000000,
            violet = 10000000,
            grey =   0,
            white =  0,
            gold =   10,  //need to divide by this
            silver = 100 // need to divide by this
        }
    }
}
