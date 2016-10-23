using System;
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
        public enum bandValueColors :Int32
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
        public enum multiplierColors
        {
            black = 1,
            brown = 10,
            red = 100,
            orange = 1000,
            yellow = 10000,
            green = 100000,
            blue = 1000000,
            violet = 10000000,
            gold = 10,  //need to divide by this
            silver = 100 // need to divide by this
        }
        public enum toleranceColors
        {
            brown = 1,
            red = 2,

            //need to divide
            green = 2, //    .5%
            blue = 4,  // .25%
            violet = 10, // .1%
            grey = 20, // .05%

            // no need to divide
            gold = 5,
            silver = 10
        }
        private int bandValue1;
        public int BandValue1
        {
            get
            {
                return bandValue1;
            }
            set
            {
                bandValue1 = value;
            }
        }

        private int bandValue2;
        public int BandValue2
        {
            get
            {
                return bandValue2;
            }
            set
            {
                bandValue2 = value;
            }
        }

        private int bandValue3;
        public int BandValue3
        {
            get
            {
                return bandValue3;
            }
            set
            {
                bandValue3 = value;
            }
        }

        private double bandMultiplier;
        public double BandMultiplier
        {
            get
            {
                return bandMultiplier;
            }
            set
            {
                bandMultiplier = value;
            }
        }

        private double bandTolerance;
        public double BandTolerance
        {
            get
            {
                return bandTolerance;
            }
            set
            {
                bandTolerance = value;
            }
        }
        public ResistorValueCalculation()
        {
            BandValue1 = 0;
            BandValue2 = 0;
            BandValue3 = 0;
            BandMultiplier = 0;
            BandTolerance = 0;
        }
        public ResistorValueCalculation(string val1, string val2, string mult, string tol)
        {
            BandValue1 = findValfromString(val1.ToLower());
            BandValue2 = findValfromString(val2.ToLower());
            BandValue3 = 0;
            BandMultiplier = findMultfromString(mult.ToLower());
            BandTolerance = findTolfromString(tol.ToLower());
        }
        public ResistorValueCalculation(string val1, string val2, string val3, string mult, string tol)
        {
            BandValue1 = findValfromString(val1.ToLower());
            BandValue2 = findValfromString(val2.ToLower());
            BandValue3 = findValfromString(val3.ToLower());
            BandMultiplier = findMultfromString(mult.ToLower());
            BandTolerance = findTolfromString(tol.ToLower());
        }

        public double EquilvaentResistance()
        {
            double temp;
            if( BandValue3 ==0 )
            {
                temp = (BandValue1 * 10) + BandValue2;
            }
            else
            {
                temp = (BandValue1 * 100) + (BandValue2 * 10) + BandValue3;
            }
            return temp * BandMultiplier;
        }
        public double EquilvaentResistanceTolerance()
        {
            double temp;
            if (BandValue3 == 0)
            {
                temp = (BandValue1 * 10) + BandValue2;
            }
            else
            {
                temp = (BandValue1 * 100) + (BandValue2 * 10) + BandValue3;
            }
            return temp * BandMultiplier * BandTolerance;
        }

        public static double parallelResistorCalc(List<double> parallelList)
        {
            double calc = 0;
            double prev = parallelList[1];
            for(int i = 1; i < parallelList.Count; i++)
            {
                if( prev !=0 || parallelList[i] != 0)
                {
                    calc = Math.Pow(1 / prev + 1 / parallelList[i], -1);
                    prev = calc;
                }
               

            }
            return calc;
        }

        public static double seriesResistorCalc(List<double> parallelList)
        {
            double calc = 0;
            foreach (var temp in parallelList)
            {
                calc += temp;

            }
            return calc;
        }

        public int findValfromString(string s)
        {
            bandValueColors enumOutput;
            int outputVal = 0;
            if ( Enum.TryParse( s, out enumOutput))
            {
                
                outputVal = (int)enumOutput; 
            }
            else
            {
                outputVal = -1; 
            }

            
            return outputVal;

        }
        public double findMultfromString(string s)
        {
            multiplierColors enumOutput;
            double outputVal = 0;
            if (Enum.TryParse(s, out enumOutput))
            {

                outputVal = (double)enumOutput;
                Console.WriteLine(outputVal);
                Console.WriteLine(enumOutput);

                if (enumOutput.ToString().CompareTo("silver") == 0 || enumOutput.ToString().CompareTo("gold") == 0 )
                {
                    outputVal = 1 / outputVal;
                }
            }
            else
            {
                outputVal = -1;
            }
            // need to divide silver, gold
            Console.WriteLine(outputVal);
            return outputVal;
        }
        public double findTolfromString(string  s)
        {
            toleranceColors enumOutput;
            double outputVal = 0;
            if (Enum.TryParse(s, out enumOutput))
            {
                outputVal = (double)enumOutput;
                if (enumOutput.ToString().CompareTo("green") == 0 || enumOutput.ToString().CompareTo("blue") == 0 ||
                    enumOutput.ToString().CompareTo("violet") == 0 || enumOutput.ToString().CompareTo("grey") == 0)
                {
                    outputVal = 1/ outputVal;
                }

                outputVal = outputVal / 100; 
            }
            else
            {
                outputVal = -1;
            }

            // need to divide by  value and 100 green, blue, violet, grey
   
            return outputVal;
        }
    }
}
