using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResistorNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistorNamespace.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ResistorNamespace;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ResistorNamespace.Tests
    {
        [TestClass()]
        public class ResistorValueCalculationTests
        {
            [TestMethod()]
            public void EquilvaentResistanceTest()
            {  //red orange red gold 
                var valTest = new ResistorValueCalculation("brown", "red", "violet", "orange", "gold");

                Assert.AreEqual(127000, valTest.EquilvaentResistance());
            }

            [TestMethod()]
            public void EquilvaentResistanceToleranceTest()
            {
                var valTest = new ResistorValueCalculation("Brown", "Red", "Violet", "Orange", "Gold");
                //Console.WriteLine( valTest.EquilvaentResistanceMax() );
                Assert.AreEqual(6350, valTest.EquilvaentResistanceTolerance());
            }
            [TestMethod()]
            public void EquilvaentResistanceTest2()
            {  //red orange red gold 
                var valTest = new ResistorValueCalculation("orange", "brown", "blue", "gold");

                Assert.AreEqual(31000000, valTest.EquilvaentResistance());
            }

            [TestMethod()]
            public void EquilvaentResistanceToleranceTest2()
            {
                var valTest = new ResistorValueCalculation("orange", "brown", "blue", "gold");
                //Console.WriteLine( valTest.EquilvaentResistanceMax() );
                Assert.AreEqual(1550000, valTest.EquilvaentResistanceTolerance());
            }
            [TestMethod()]
            public void parallelResistorCalcTest()
            {
                List<double> parallelList = new List<double>()
            {
                1000, 1000
            };
                //Console.WriteLine(ResistorValueCalculation.parallelResistorCalc(parallelList));
                Assert.AreEqual(500, ResistorValueCalculation.parallelResistorCalc(parallelList), 5);
            }
            [TestMethod()]
            public void parallelResistorCalcTest2()
            {
                List<double> parallelList = new List<double>()
            {
                1000, 1000, 1000
            };
                //Console.WriteLine(ResistorValueCalculation.parallelResistorCalc(parallelList));
                Assert.AreEqual(333, ResistorValueCalculation.parallelResistorCalc(parallelList), 5);
            }
            [TestMethod()]
            public void seriesResistorCalcTest()
            {
                List<double> seriesList = new List<double>()
            {
                1000, 250, 400,10000
            };
                Assert.AreEqual(11650, ResistorValueCalculation.seriesResistorCalc(seriesList));
            }
            [TestMethod()]
            public void seriesResistorCalcTest2()
            {
                List<double> seriesList = new List<double>()
            {
                1000,10000
            };
                Assert.AreEqual(11000, ResistorValueCalculation.seriesResistorCalc(seriesList));
            }
            [TestMethod()]
            public void seriesResistorCalcTest3()
            {
                List<double> seriesList = new List<double>()
            {
                1000,1000,1000,1000,1000,1000,1000,1000,1000
            };
                Assert.AreEqual(9000, ResistorValueCalculation.seriesResistorCalc(seriesList));
            }

            [TestMethod()]
            public void findValfromStringTest()
            {
                var valTest = new ResistorValueCalculation("brown", "red", "red", "gold");

                Assert.AreEqual(1, valTest.BandValue1);
                Assert.AreEqual(2, valTest.BandValue2);
                Assert.AreEqual(0, valTest.BandValue3);
            }
            [TestMethod()]
            public void findValfromStringTest2()
            {
                var valTest = new ResistorValueCalculation("brown", "red", "violet", "orange", "gold");

                Assert.AreEqual(1, valTest.BandValue1);
                Assert.AreEqual(2, valTest.BandValue2);
                Assert.AreEqual(7, valTest.BandValue3);
            }
            [TestMethod()]
            public void findMultfromStringTest()
            {
                var valTest = new ResistorValueCalculation("brown", "red", "violet", "orange", "gold");

                Assert.AreEqual(1000, valTest.BandMultiplier);
            }

            [TestMethod()]
            public void findTolfromStringTest()
            {
                var valTest = new ResistorValueCalculation("brown", "red", "violet", "orange", "gold");

                Assert.AreEqual(0.05, valTest.BandTolerance);
            }
            [TestMethod()]
            public void findTolfromStringTest2()
            {
                var valTest = new ResistorValueCalculation("brown", "red", "violet", "grey", "blue");

                Assert.AreEqual(0.0025, valTest.BandTolerance);
            }

        }
    }
}