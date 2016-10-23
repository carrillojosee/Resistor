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

            if(fourBands.IsEnabled)
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


    }
}
