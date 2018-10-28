using MathTools.NonlinearSolver;
using Modules.Base.Logic;
using Modules.Base.Manager;
using System;

namespace Modules.Logic
{
    public class ModulesCalculator : IModulesCalculator
    {
        public ISoilModel SoilModel { get; set; }
        public double DerivativeAccuracy { get; set; }
        public ModulesCalculator(ISoilModel model)
        {
            SoilModel = model;
            DerivativeAccuracy = 0.000001;
        }

        public double GetSecantModulus(double ratio)
        {
            double stress = ratio * SoilModel.GetFailureStress();
            var solver = new NewtonSolver(x => SoilModel.GetDeviatoricStress(x) - stress, 0);
            double eps = solver.Solve();

            if (eps == 0) throw new Exception();

            return stress/eps;
        }

        public double GetTangentModulus(double ratio)
        {
            double stress = ratio * SoilModel.GetFailureStress();
            var solver = new NewtonSolver(x => SoilModel.GetDeviatoricStress(x) - stress, 0);
            double eps = solver.Solve();

            var derivative = new Derivative(x => SoilModel.GetDeviatoricStress(x), DerivativeAccuracy);

            return derivative.GetFirstDerivative(eps);
        }


    }
}
