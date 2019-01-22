using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modules.Base.Model;
using Modules.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Manager.Tests
{
    [TestClass()]
    public class SieveCoefficientsTests
    {
        [TestMethod()]
        public void GetCurvatureTest()
        {

 
        }
        
        [TestMethod()]
        public void GetUniformityTest()
        {
            double d10 = 0.1;
            double d60 = 1;
            var SieveParameters = new SieveParameter() {D10=d10,D60=d60 };
            var SieveCoef = new SieveCoefficients();
            SieveCoef.SieveParameters = SieveParameters;
            var expected = d60 / d10;

            Console.WriteLine();
            double res=SieveCoef.GetUniformity();

            Assert.AreEqual(expected,res);
        }
    }
}