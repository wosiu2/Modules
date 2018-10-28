using Modules.Base.Manager;
using System;


namespace Modules.Manager
{
    public class DuncanSoilModel : ISoilModel
    {
        private IDuncanParameters _duncanParameters;
        private IStrengthParameters _strengthParameters;
        public double ConfiningPressure { get; set; }
        public double AtmosphericPressure { get; set; }

        public DuncanSoilModel(IStrengthParameters strengthManager, IDuncanParameters duncanParametersManager)
        {
            _duncanParameters = duncanParametersManager;
            _strengthParameters = strengthManager;
        }

        public double GetDeviatoricStress(double eps)
        {
            double ultimateStress = GetUltimateStress();
            double initialModulus = GetInitialModulus();
            if (ultimateStress == 0|| initialModulus==0)
            {
                return 0;
            }
            double baseValue = 1/initialModulus + eps/ ultimateStress;

            if (baseValue==0)
            {
                return 0;
            }

            return eps/baseValue;
        }

        public double GetUltimateStress()
        {
            if (_duncanParameters.FailureRatio==0)
            {
                return 0;
            }
            return GetFailureStress()/ _duncanParameters.FailureRatio;
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
