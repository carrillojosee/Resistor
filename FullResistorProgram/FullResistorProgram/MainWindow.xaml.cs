using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ResistorNamespace;
using FullResistorProgram;
using System.IO;

namespace FullResistorProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         


        }

        private ResistorValueCalculation bandResisFour = new ResistorValueCalculation();
        private ResistorValueCalculation bandResisFive = new ResistorValueCalculation();

        private void ResistorColorBandButton_Click(object sender, RoutedEventArgs e)
        {

            if( (bool)fourBands.IsChecked && (bool)!fiveBands.IsChecked)
            {

                bandResisFour.BandValue1 = bandResisFour.findValfromString(ColorBands1.Text.ToLower());
                bandResisFour.BandValue2 = bandResisFour.findValfromString(ColorBands2.Text.ToLower());
                bandResisFour.BandValue3 = 0;
                bandResisFour.BandMultiplier = bandResisFour.findMultfromString(multiplierBand.Text.ToLower());
                bandResisFour.BandTolerance = bandResisFour.findTolfromString(toleranceBand.Text.ToLower());

                ResistorColorBandOutput.Text = bandResisFour.EquilvaentResistance().ToString()+ " +/- " +
                    bandResisFour.EquilvaentResistanceTolerance().ToString() + " Ω";
            }
            else
            {
                bandResisFive.BandValue1 = bandResisFive.findValfromString(ColorBands1.Text.ToLower());
                bandResisFive.BandValue2 = bandResisFive.findValfromString(ColorBands2.Text.ToLower());
                bandResisFive.BandValue3 = bandResisFive.findValfromString(ColorBands3.Text.ToLower()); ;
                bandResisFive.BandMultiplier = bandResisFive.findMultfromString(multiplierBand.Text.ToLower());
                bandResisFive.BandTolerance = bandResisFive.findTolfromString(toleranceBand.Text.ToLower());

                ResistorColorBandOutput.Text = bandResisFive.EquilvaentResistance().ToString() + " +/- " +
                    bandResisFive.EquilvaentResistanceTolerance().ToString() + " Ω";
            }
        }
        private List<double> inputResisListDouble = new List<double>();

        private void equivalentResistoCalc_Click(object sender, RoutedEventArgs e)
        {
            //inputResistance
            //outputResistanceEquivalent
            List<string> tempString = inputResistance.Text.Split(new char[] { ',' }).ToList();
            inputResisListDouble = tempString.Select(x => double.Parse(x)).ToList();

            

            if (  (bool)seriesRadioButton.IsChecked  && (bool)!parallelRadioButton.IsChecked )
            {
                outputResistanceEquivalent.Text = ResistorValueCalculation.seriesResistorCalc(inputResisListDouble).ToString();
            }
            else
            {
                outputResistanceEquivalent.Text = ResistorValueCalculation.parallelResistorCalc(inputResisListDouble).ToString();
            }
        }
        private FindResistor ResisEQ = new FindResistor();
        //private FindResistor ResisEQParallel;

        private void EQresistanceWantedButton_Click(object sender, RoutedEventArgs e)
        {
            //resistanceEQwanted
            //EQresisWantedOutput
            //Console.WriteLine(Convert.ToDouble(resistanceEQwanted.Text));

            //clear contents 
            EQresisWantedOutput.Text = "";

            ResisEQ.findAll(Convert.ToDouble(resistanceEQwanted.Text ) );
            StreamWriter file = new StreamWriter(@"C:\@code\Resistor_Program\outputResis2.txt");

            if ((bool)seriesRadioButton2.IsChecked && (bool)!parallelRadioButton2.IsChecked)
            {
                foreach (var x in ResisEQ.resistor_S_List)
                {
                    file.WriteLine(x.ToString());
                    EQresisWantedOutput.Text += x.ToString() + "\n";
                }
            }
            else
            {
                foreach (var x in ResisEQ.resistor_P_List)
                {
                    file.WriteLine(x.ToString());
                    EQresisWantedOutput.Text += x.ToString() + "\n";
                }
            }

            file.Flush(); //clears buffers

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
