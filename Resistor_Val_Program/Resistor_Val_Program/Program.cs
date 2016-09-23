using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResistorNamespace;
namespace Resistor_Val_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Resistor temp = new Resistor();

            var b = Resistor.resistorValues;
            Console.WriteLine("Executing match method: " + temp.match(1000));
            Console.WriteLine("1000 =" + b[temp.match(1000)]);
            temp.findResistorsSeries(2500);
            temp.findResistorSeries3(2500);

            foreach (var x in Resistor.resistorsSeries)
            {
                Console.WriteLine( x.ToString() );

            }
            //temp.findResistorSeries3();

            Console.ReadLine();
        }
    }
}
