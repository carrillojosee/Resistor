using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistorNamespace
{

    public class EquivalentResistor
    {
        public double firstR { get; set; }
        public double secondR { get; set; }
        public double thirdR { get; set; }
        public string p_or_s { get; set; }
        public EquivalentResistor(double a, string parallel_series)
        {
            firstR = a;
            secondR = -1;
            thirdR = -1;
            p_or_s = parallel_series;
        }
        public EquivalentResistor(double a, double b, string parallel_series)
        {
            firstR = a;
            secondR = b;
            thirdR = -1;
            p_or_s = parallel_series;

        }
        public EquivalentResistor(double a, double b, double c, string parallel_series)
        {
            firstR = a;
            secondR = b;
            thirdR = c;
            p_or_s = parallel_series;

        }
        public double sum()
        {
            if (thirdR == -1 && secondR == -1)
            {
                return firstR;
            }
            else if (thirdR == -1)
            {
                return firstR + secondR;
            }
            else
            {
                return firstR + secondR + thirdR;
            }
        }
        public double parallelEQ()
        {
            if (thirdR == -1 && secondR == -1)
            {
                return firstR;
            }
            else if (thirdR == -1)
            {
                double tempVal = 1 / firstR + 1 / secondR;
                return Math.Pow(tempVal, -1);
            }
            else
            {
                double tempVal = 1 / firstR + 1 / secondR + 1 / thirdR;
                return Math.Pow(tempVal, -1);
            }
        }

        public double parallelEquiv( List<double> tempList)
        {
            double a = tempList[0];
            double equiParallel = 0;
            if(tempList.Count > 0)
            {
                for (int i = 1; i < tempList.Count; i++)
                {
                    equiParallel = 1 / equiParallel + 1 / tempList[i];
                }
                return Math.Pow(equiParallel, -1);
            }
            else
            {
                return -1; 
            }

        }
        public override string ToString()
        {
            //string tempString = "";
            //if (p_or_s.Equals("series");
            //string temp = p_or_s == "Series" ? sum.toString() : parallelEQ().toString();
            if (thirdR == -1 && secondR == -1)
            {
                return "Resistor " + firstR.ToString() +
                     "=" + sum().ToString();
            }
            else if (thirdR == -1)
            {
                return p_or_s + " " + firstR.ToString() +
                     "+" + secondR.ToString() + "=" + (p_or_s == "Series" ? sum().ToString() : parallelEQ().ToString());
                // p_or_s =="Series": sum.toString(): parallelEQ.toString()
            }
            else
            {
                return p_or_s + " " + firstR.ToString() +
                     "+" + secondR.ToString() + "+" + thirdR.ToString() + "=" + (p_or_s == "Series" ? sum().ToString() : parallelEQ().ToString());
            }
        }
    }
}
