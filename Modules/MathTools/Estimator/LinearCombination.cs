using MathTools.Estimator.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTools.Estimator
{
    public class LinearCombination : ILinearCombination<double, double>
    {
        public double GetLinearCombination(IEnumerable<double> a, IEnumerable<double> x)
        {
            double combination = 0;

            var concat = a.Zip(x, (_a, _x) => new { A = _a, X = _x });

            foreach(var element in concat)
            {
                combination += element.A * element.X;
            }

            return combination;
        }
    }
}
