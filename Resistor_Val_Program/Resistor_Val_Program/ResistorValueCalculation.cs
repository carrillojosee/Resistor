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
        public enum bandValueColors
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
            black =  1,
            brown =  10,
            red =    100,
            orange = 1000,
            yellow = 10000,
            green =  100000,
            blue =   1000000,
            violet = 10000000,
            gold =   10,  //need to divide by this
            silver = 100 // need to divide by this
        }
        public enum toleranceColors
        {
            brown = 1,
            red = 2,

            //need to divide
            green = 2,
            blue = 4,
            violet = 10,
            grey = 20,

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

        }
        public ResistorValueCalculation(int val1, int val2, double mult, double tol)
        {
            BandValue1 = val1;
            BandValue2 = val2;
            BandValue3 = 0; 
            BandMultiplier = mult;
            BandTolerance = tol; 
        }
        public ResistorValueCalculation(int val1, int val2, int val3, int mult, int tol)
        {
            BandValue1 = val1;
            BandValue2 = val2;
            BandValue3 = val3;
            BandMultiplier = mult;
            BandTolerance = tol;
        }

        public double EquilvaentResistanceMin()
        {
            int temp1, temp2, temp3;
            temp1 = BandValue1 == 0 ? 0: BandValue1;
            temp2 = BandValue2 == 0 ? 0 : BandValue1;
            temp3 = BandValue2 == 0 ? 0 : BandValue1;

            double temp = (temp1 + 100) + (temp2 + 10) + temp3;
            return temp * BandMultiplier * (1 - BandTolerance) ;
        }
        public double EquilvaentResistanceMax()
        {
            int temp1, temp2, temp3;
            temp1 = BandValue1 == 0 ? 0 : BandValue1;
            temp2 = BandValue2 == 0 ? 0 : BandValue1;
            temp3 = BandValue2 == 0 ? 0 : BandValue1;

            double temp = (temp1 + 100) + (temp2 + 10) + temp3;
            return temp * BandMultiplier * (1 + BandTolerance);
        }

        public double parallelResistorCalc( List<double> parallelList)
        {
            double calc = 0;
            double prev = 0;
            foreach(var temp in parallelList)
            {
                calc += Math.Pow(1 / prev + 1 / temp , -1) ;

            }
            return calc; 
        }

        public double seriesResistorCalc(List<double> parallelList)
        {
            double calc = 0;
            foreach (var temp in parallelList)
            {
                calc += temp;

            }
            return calc;
        }
    }
}
