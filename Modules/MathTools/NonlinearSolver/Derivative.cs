
using MathTools.NonlinearSolver.Abstraction;
using System;

namespace MathTools.NonlinearSolver
{
    public class Derivative : IDerivative<double>
    {
        public Func<double, double> Function { get; set; }
        public double Step { get; set; }


        public Derivative(Func<double,double> function, double step)
        {
            Function = function;
            Step = step;
        }

        public double GetFirstDerivative(double point)
        {
            if (Step == 0)
            {
                return 0;
            }
            return (Function(point + Step)-Function(point))/Step;
        }

        public double GetSecondDerivative(double point)
        {
            if (Step == 0)
            {
                return 0;
            }
            return (Function(point + 2*Step) - 2*Function(point+ Step)+ Function(point)) / (Step*Step);
        }
    }
}
