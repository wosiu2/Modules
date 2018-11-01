using Modules.Base.Manager;
using Modules.Base.Model;
using System;

namespace Modules.Manager
{
    public class SDMBasedParametersManager : IDuncanParameters,IStrengthParameters
    {
        private SieveCoefficients _sieveCoefficients;
        private SoilSample _sample;
        public double FailureRatio { get => 0.7; }
        public double FrictionAngle { get => GetFrictionAngle(); }
        public double Exponent { get => GetExponent(); }
        public double K { get => GetB() * GetMCoefficient(); }
        public SoilSample SoilSample {
            get => _sample;
            set
            {
                _sample = value;
                _sieveCoefficients.SieveParameters = _sample.SieveParameter;

            }
        }
        public double Cohesion { get; set; }

        public SDMBasedParametersManager()
        {
            _sieveCoefficients = new SieveCoefficients();
            SoilSample = new SoilSample();

        }
        private double GetFrictionAngle()
        {
            double Cu = _sieveCoefficients.GetUniformity();   
            return 26+10*(SoilSample.Compaction-75)/25+0.4*Cu+1.6*Math.Log10(SoilSample.SieveParameter.D50);
        }
        
        private double GetExponent()
        {
            double Cu = _sieveCoefficients.GetUniformity();
            return 1-(0.29*Math.Log10(_sample.SieveParameter.D50/0.01)- 0.065 * Math.Log10(Cu)) ;
        }
        private double GetB()
        {
            double s = Math.Sin(GetFrictionAngleRad()) * (3 - 2 * Math.Sin(GetFrictionAngleRad())) / (2 - Math.Sin(GetFrictionAngleRad()));
            return s;
        }
        private double GetMCoefficient()
        {
            double Cu = _sieveCoefficients.GetUniformity();

            if (SoilSample.SolidWeight == 0)
            {
                return 0;
            }

            double e0 = SoilSample.SolidWeight/ SoilSample.Weight - 1;
            double x = 282 * Math.Pow(Cu, -0.77) * Math.Pow(e0, -2.83);
            return x;
        }
        public double GetFrictionAngleRad()
        {
            return FrictionAngle * Math.PI / 180;
        }
    }
}
