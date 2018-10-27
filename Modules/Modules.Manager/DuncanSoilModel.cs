using Modules.Base.Manager;
using System;


namespace Modules.Manager
{
    public class DuncanSoilModel : ISoilModel,IInitialModulus
    {
        private IDuncanParameters _duncanParameters;
        private IStrengthParameters _strengthParameters;
        public double ConfiningPressure { get; set; }
        public double AtmosphericPressure { get; set; }

        public double GetDeviatoricStress(double eps)
        {
            double ultimateStress = GetUltimateStress();

            if (ultimateStress == 0)
            {
                return 0;
            }
            double baseValue = GetInitialModulus()+eps/ ultimateStress;

            if (baseValue==0)
            {
                return 0;
            }

            return eps/baseValue;
        }

        public double GetUltimateStress()
        {
            return GetFailureStress()* _duncanParameters.FailureRatio;
        }

        public double GetFailureStress()
        {
            return (2* _strengthParameters.Cohesion*Math.Cos(_strengthParameters.GetFrictionAngleRad()) + 
                2 * ConfiningPressure * Math.Sin(_strengthParameters.GetFrictionAngleRad()))/
                (1-Math.Sin(_strengthParameters.GetFrictionAngleRad()));
        }

        public double GetInitialModulus()
        {
            if (AtmosphericPressure == 0) return 0;

            return _duncanParameters.K * AtmosphericPressure * Math.Pow((ConfiningPressure / AtmosphericPressure), _duncanParameters.Exponent);
        }

    }
}
