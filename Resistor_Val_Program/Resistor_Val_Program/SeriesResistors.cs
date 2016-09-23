using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistorNamespace
{
    public class SeriesResistors
    {
        public double firstR { get; set; }
        public double secondR { get; set; }
        public double thirdR { get; set; }

        public SeriesResistors( double a, double b)
        {
            firstR = a;
            secondR = b;
            thirdR = -1;
        }
        public SeriesResistors(double a, double b, double c)
        {
            firstR = a;
            secondR = b;
            thirdR =  c;
        }
        public double sum()
        {
            if(thirdR ==-1 )
            {
                return firstR + secondR;
            }
            else
            {
                return firstR + secondR + thirdR;
            }
        }
        public override string ToString()
        {
            if (thirdR == -1)
            {
                return "Series Resistors:" + firstR.ToString() +
                     "+" + secondR.ToString() + "=" + sum().ToString(); 
            }
            else
            {
                return "Series Resistors:" + firstR.ToString() +
                     "+" + secondR.ToString() + "+" + thirdR.ToString() + "=" + sum().ToString();
            }
        }
    }
}
