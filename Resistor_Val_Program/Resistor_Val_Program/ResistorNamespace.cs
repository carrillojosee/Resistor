﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistorNamespace
{
    public class Resistor
    {

        public static  List<double> resistorsSeries = new List<double>();
        public static readonly List<double> resistorValues = new List<double>()
        {
            1.0, 10, 100, 1000, 10000, 100000, 1000000,
            1.1, 11, 110, 1100, 11000, 110000, 1100000,
            1.2, 12, 120, 1200, 12000, 120000, 1200000,
            1.3, 13, 130, 1300, 13000, 130000, 1300000,
            1.5, 15, 150, 1500, 15000, 150000, 1500000,
            1.6, 16, 160, 1600, 16000, 160000, 1600000,
            1.8, 18, 180, 1800, 18000, 180000, 1800000,
            2.0, 20, 200, 2000, 20000, 200000, 2000000,
            2.2, 22, 220, 2200, 22000, 220000, 2200000,
            2.4, 24, 240, 2400, 24000, 240000, 2400000,
            2.7, 27, 270, 2700, 27000, 270000, 2700000,
            3.0, 30, 300, 3000, 30000, 300000, 3000000,
            3.3, 33, 330, 3300, 33000, 330000, 3300000,
            3.6, 36, 360, 3600, 36000, 360000, 3600000,
            3.9, 39, 390, 3900, 39000, 390000, 3900000,
            4.3, 43, 430, 4300, 43000, 430000, 4300000,
            4.7, 47, 470, 4700, 47000, 470000, 4700000,
            5.1, 51, 510, 5100, 51000, 510000, 5100000,
            5.6, 56, 560, 5600, 56000, 560000, 5600000,
            6.2, 62, 620, 6200, 62000, 620000, 6200000,
            6.8, 68, 680, 6800, 68000, 680000, 6800000,
            7.5, 75, 750, 7500, 75000, 750000, 7500000,
            8.2, 82, 820, 8200, 82000, 820000, 8200000,
            9.1, 91, 910, 9100, 91000, 910000, 9100000
         };

        public int match(double x)
        {
            //foreach( var b in resistorValues)
            //{ 
            //    if( b == x)
            //    {
            //        return 1; 
            //    }
    
            //}
            //for( int i =0; i < resistorValues.Count; i++)
            // {

            //}
           return resistorValues.IndexOf(x);
           // return -1; 
        }
        public void findResistorsSeries(double x)
        {
            for( int a = 0; a < resistorValues.Count-1; a++)
            {
                for (int b = a+1; b < resistorValues.Count; b++)
                {

                    Console.WriteLine(resistorValues[a] + ":" + resistorValues[b]);
                    if ( (a + b >= (x - x*.1)) && (a + b >= (x +x*.1) )) 
                    {
                        resistorsSeries.Add(resistorValues[a]);
                        resistorsSeries.Add(resistorValues[b]);
                        Console.WriteLine(a + ":" + b + ":");

                    }

                }
            }
        }
    }
}
