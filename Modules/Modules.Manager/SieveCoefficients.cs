using Modules.Base.Manager;
using Modules.Base.Model;
using System;


namespace Modules.Manager
{
    public class SieveCoefficients : ISieveCoefficient
    {
        public SieveParameter SieveParameters { get; set; }

        public double GetCurvature()
        {
            if (SieveParameters.D60 * SieveParameters.D10==0)
            {
                return 0;
            }
            return Math.Pow(SieveParameters.D30, 2) / (SieveParameters.D60 * SieveParameters.D10);
        }

        public double GetUniformity()
        {
            if ( SieveParameters.D10 == 0)
            {
                return 0;
            }
            return (SieveParameters.D60 / SieveParameters.D10);
        }
    }
}
