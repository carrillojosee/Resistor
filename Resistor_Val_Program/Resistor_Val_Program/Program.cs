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

            //var b = Resistor.resistorValues;
            //Console.WriteLine("Executing match method: " + temp.match(1000));
            //Console.WriteLine("1000 =" + b[temp.match(1000)]);
            temp.findResistor(2500);
            temp.findResistorsSeries(2500);
            temp.findResistorSeries3(2500);
            temp.findResistorsParallel(2500);
            temp.findResistorParallel3(2500);

            StreamWriter file = new StreamWriter(@"C:\@code\Resistor_Program\outputResis2.txt");
            foreach (var x in temp.resistorsSeries)
            {
                file.WriteLine( x.ToString() );
            }
            file.Flush(); //clears buffers
            Console.WriteLine(temp.resistorsSeries[temp.resistorsSeries.Count -1].ToString());
            //temp.findResistorSeries3();
            //Console.WriteLine(temp.resistorsSeries.Count);
            Console.ReadLine();
        }
    }
}
