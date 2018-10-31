using MathTools.BaseModel;
using MathTools.Estimator.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MathTools.Estimator
{
    public class TwoPointEstimator : IEstimator<double,Point>
    {
        private ILinearCombination<double, double> _combination;
        public IEnumerable<Point> EstimatorData { get; set; }

        public TwoPointEstimator()
        {
            _combination = new LinearCombination();
        }

        public double Estimate(double x)
        {
            var list = EstimatorData.OrderBy(n => n.X);
            Point p1=null,p2=null;       

            foreach(var p in list)
            {
                if (p1 == null)
                {
                    p1 = p;
                    continue;
                }
                if (p2 == null)
                {
                    p2 = p;
                    continue;
                }

                if (p1.X >= x && p2.X >= x)
                {
                    break;
                }
                if (p1.X<=x&&p2.X>=x)
                {
                    break;
                }
                p1 = p2;
                p2 = p;
            }


            return SingleEstimation(x, p1, p2);
        }

        private  double SingleEstimation(double x,Point a,Point b)
        {
            var baseValue = b.X - a.X;
            var topValue = x - a.X;

            if (baseValue==0)
            {
                throw new Exception();
            }
            
            return _combination.GetLinearCombination(
                new double[] {1- topValue/ baseValue , topValue / baseValue }, 
                new double[] {a.Y,b.Y });
        }

    }
}
