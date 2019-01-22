using Modules.Base.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Manager.Triaxial
{
    public class MohrCohesiveParameters : IStrengthParameters
    {
        public double FrictionAngle => throw new NotImplementedException();

        public double IncrementFrictionAngle => throw new NotImplementedException();

        public double Cohesion => throw new NotImplementedException();

        public double FrictionAngleRadians => throw new NotImplementedException();

        public double IncrementFrictionAngleRadians => throw new NotImplementedException();
    }
}
