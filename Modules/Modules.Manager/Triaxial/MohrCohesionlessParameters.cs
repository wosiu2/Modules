using MathTools.BaseModel;
using MathTools.Regression;
using MathTools.Regression.Abstraction;
using Modules.Base.Manager;
using Modules.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Modules.Manager.Triaxial
{
    public class MohrCohesionlessParameters : IStrengthParameters
    {

        public double FrictionAngle { get; private set; }

        public double IncrementFrictionAngle { get; private set; }

        public double FrictionAngleRadians { get; private set; }

        public double IncrementFrictionAngleRadians { get; private set; }

        public double Cohesion => 0;
       
        private double _atmosphericPressure; 

        private IRegression _regressionManager;


        public MohrCohesionlessParameters(IEnumerable<TriaxialTest> _listOfTraxialTests,double _atm=100)
        {
            _regressionManager = new LinearRegression();
            _atmosphericPressure = _atm;
            ResolveParameters(_listOfTraxialTests);
        }

        public void ResolveParameters(IEnumerable<TriaxialTest> _listOfTraxialTests)
        {
            var listOfAngles = new List<double>();

            var testResults = GetListOfConfiningPressures(_listOfTraxialTests)
                .Zip(GetListOfPoints(_listOfTraxialTests),(conf,res)=>new { Confining=conf,Failure=res});

            foreach (var sample in testResults)
            {
                listOfAngles.Add(ResultantFrictionAngle(sample.Failure.Y, sample.Confining));
            }

            var relativePressures = GetListOfConfiningPressures(_listOfTraxialTests)
                .Select(n=>Math.Log10(n / _atmosphericPressure)).ToList();

            _regressionManager.Update(relativePressures, listOfAngles);

            FrictionAngleRadians = _regressionManager.GetValue(0);

            IncrementFrictionAngleRadians = FrictionAngleRadians-_regressionManager.GetValue(1) ;

            FrictionAngle= FrictionAngleRadians * 180 / Math.PI;
            IncrementFrictionAngle= IncrementFrictionAngleRadians * 180 / Math.PI;
        }

        public double ResultantFrictionAngle(double deviatoricStress,double confiningStress)
        {
            double axialStress = deviatoricStress + confiningStress;
            double resultantFrictionAngle = Math.Asin((axialStress-confiningStress) /(axialStress+confiningStress));
            return resultantFrictionAngle;
        }

        public IEnumerable<double> GetListOfConfiningPressures(IEnumerable<TriaxialTest> _listOfTraxialTests)
        {
            return _listOfTraxialTests
                .OrderBy(n => n.ConfiningPressure)
                .Select(n => n.ConfiningPressure).ToArray();
        }

        public IEnumerable<Point> GetListOfPoints(IEnumerable<TriaxialTest> _listOfTraxialTests)
        {
    
            return _listOfTraxialTests
                 .OrderBy(n => n.ConfiningPressure)
                 .Select(n => n.TestResults.OrderBy(k => k.Y).LastOrDefault()).ToArray();
            
        }
    }
}
