using Modules.Base.Manager;
using Modules.Base.Model;
using System;

namespace Modules.Manager
{
    public class SDMBasedParametersManager : IDuncanParameters,IStrengthParameters
    {
        private ISieveCoefficient _sieveCoefficients;
        private SoilSample _sample;
        public double FailureRatio { get; private set; }
        public double FrictionAngle { get; private set; }
        public double Exponent { get ; private set; }
        public double K { get; private set; }
        public SoilSample SoilSample {
            get => _sample;
            set
            {
                _sample = value;
                FrictionAngle = GetFrictionAngle();
                Exponent = GetExponent();
                K = GetK()* GetMCoefficient();
            }
        }

        public double Cohesion { get; set; }

        private double GetFrictionAngle()
        {
            double Cu = _sieveCoefficients.GetUniformity();   
            return 26+10*(SoilSample.Compaction-75)/25+0.4*Cu+1.6*Math.Log10(SoilSample.SieveParameters.D50);
        }
        
        private double GetExponent()
        {
            double Cu = _sieveCoefficients.GetUniformity();
            return 1-(0.29*Math.Log10(_sample.SieveParameters.D50/0.01)- 0.065 * Math.Log10(Cu)) ;
        }
        private double GetK()
        {
            return Math.Sin(GetFrictionAngleRad())*(3-2* Math.Sin(GetFrictionAngleRad()))/(2- Math.Sin(GetFrictionAngleRad()));
        }
        private double GetMCoefficient()
        {
            double Cu = _sieveCoefficients.GetUniformity();

            if (SoilSample.SolidWeight == 0)
            {
                return 0;
            }

            double e0 = SoilSample.Weight / SoilSample.SolidWeight - 1;
            return 282 * Math.Pow(Cu, -0.77) * Math.Pow(e0, -2.83);
        }
        public double GetFrictionAngleRad()
        {
            return FrictionAngle * Math.PI / 180;
        }
    }
}
