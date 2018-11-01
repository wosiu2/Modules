
using MathTools.NonlinearSolver.Abstraction;
using System;

namespace MathTools.NonlinearSolver
{
    public class NewtonSolver : INonLinearSolver<double>
    {
        private Func<double, double> _function;
        public double StartPoint { get; set; }
        public double Eps0 { get; set; }
        public double EpsX { get; set; }
        public int MaxIterations { get; set; }

        public Func<double, double> Function
        {
            get
            {
                return _function;
            }
            set
            {
                _function = value;
                Derivative = new Derivative(_function, 0.001);
            }
        }

        private IDerivative<double> Derivative { get; set; }

        public NewtonSolver(Func<double, double> function, double start)
        {
            Function = function;
            StartPoint = start;
            Eps0 = 0.00001;
            EpsX = 0.00001;
            MaxIterations = 150;
            Derivative = new Derivative(function, 0.001);
        }

        public double Solve()
        {
            double x0 = StartPoint;
            double x1 = StartPoint - 1;

            for (int i = 0; i < MaxIterations; i++)
            {
                if (Math.Abs(x1 - x0) < EpsX || Math.Abs(Function(x0)) < Eps0)
                {
                    
                    return x0;
                }
                if (Derivative.GetFirstDerivative(x0) <Eps0) break;
                x1 = x0;
                x0 -= Function(x0) / Derivative.GetFirstDerivative(x0);
            }

            throw new Exception();
        }
    }
}
