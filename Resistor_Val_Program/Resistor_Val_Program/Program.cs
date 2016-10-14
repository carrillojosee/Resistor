using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResistorNamespace;
using System.IO; 
namespace Resistor_Val_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Resistor temp = new Resistor();

            List<double> inputResistorsAvailableByUser = new List<double>()
            {
                1000, 5000,500,320
            };
            List<double> tempList = Resistor.resistorValues;
            Console.WriteLine("List of Standard Resistors");
            for( int a  = 0; a <= tempList.Count-1; a++)
            {

                Console.Write(tempList[a] + "\t");
                if( (a+1) % 7 == 0 && a != 0 )
                {
                    Console.WriteLine();
                }
                //else if( a== 0 || (a)%7 == 0 )
                //{
                //    Console.Write("\t");
                //}
                                

            }
            //var b = Resistor.resistorValues;
            //Console.WriteLine("Executing match method: " + temp.match(1000));
            //Console.WriteLine("1000 =" + b[temp.match(1000)]);
            temp.findAll(2500);
            //temp.findResistor(2500);
            //temp.findResistorSeries(2500);
            //temp.findResistorSeries3(2500);
            //temp.findResistorParallel(2500);
            //temp.findResistorParallel3(2500);

            StreamWriter file = new StreamWriter(@"C:\@code\Resistor_Program\outputResis2.txt");
            foreach (var x in temp.resistor_P_S_List)
            {
                file.WriteLine( x.ToString() );
            }
            file.Flush(); //clears buffers
            //Console.WriteLine(temp.resistor_P_S_List[temp.resistor_P_S_List.Count -1].ToString());
            //temp.findResistorSeries3();
            //Console.WriteLine(temp.resistorsSeries.Count);
           ResistorValueCalculation temp3 = new ResistorValueCalculation();
           Console.WriteLine((int)ResistorValueCalculation.toleranceColors.grey);
           Console.ReadLine();
        }
    }
}
