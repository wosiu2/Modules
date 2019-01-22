using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathTools.BaseModel;
using Modules.Base.Model;
using Modules.Manager.Triaxial;
using System.Collections;

namespace Modules.ManagerTests
{
    /// <summary>
    /// Summary description for MohrCohesionlessParameters
    /// </summary>
    [TestClass]
    public class MohrCohesionlessParametersTests
    {
        public MohrCohesionlessParametersTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetListOfConfiningPressures()
        {
            var listA = new Point[] {
                new Point() {X=1,Y=2 },
                new Point() {X=2,Y=3 },
                new Point() {X=3,Y=3.2 },
                new Point() {X=4,Y=3.0 },
                new Point() {X=5,Y=3.1 }
            };
            var listB = new Point[] {
                new Point() {X=0,Y=2 },
                new Point() {X=4,Y=3 },
                new Point() {X=8,Y=3.2 },
                new Point() {X=12,Y=3.4 },
                new Point() {X=16,Y=3.4 }
            };

            var listOfTests = new TriaxialTest[] {
                new TriaxialTest() {ConfiningPressure=300,TestResults=listA },
                new TriaxialTest() {ConfiningPressure=100,TestResults=listB }
            };

            var expect = new double[] {100,300 };

            var MohrCohesionelessParameters = new MohrCohesionlessParameters();

            var result = MohrCohesionelessParameters.GetListOfConfiningPressures(listOfTests);


            CollectionAssert.AreEqual(expect, (ICollection)result);

        }

        [TestMethod]
        public void GetListOfPoints()
        {
            var listA = new Point[] {
                new Point() {X=1,Y=2 },
                new Point() {X=2,Y=3 },
                new Point() {X=3,Y=3.2 },
                new Point() {X=4,Y=3.0 },
                new Point() {X=5,Y=3.1 }
            };
            var listB = new Point[] {
                new Point() {X=0,Y=2 },
                new Point() {X=4,Y=3 },
                new Point() {X=8,Y=3.2 },
                new Point() {X=12,Y=3.4 },
                new Point() {X=16,Y=3.2 }
            };

            var listOfTests = new TriaxialTest[] {
                new TriaxialTest() {ConfiningPressure=300,TestResults=listA },
                new TriaxialTest() {ConfiningPressure=100,TestResults=listB }
            };

            var expect = new Point[] {
               (Point)listB.GetValue(3),
               (Point)listA.GetValue(2)};

            var MohrCohesionelessParameters = new MohrCohesionlessParameters(listOfTests);

            var result = MohrCohesionelessParameters.GetListOfPoints(listOfTests);

            MohrCohesionelessParameters.ResolveParameters(listOfTests);

            CollectionAssert.AreEqual(expect,(ICollection)result);

        }


    }
}
