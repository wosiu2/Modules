using System;
using System.Collections.Generic;

namespace MathTools.Regression.Abstraction
{
    public interface IRegression
    {
        void Update(IEnumerable<double> _dataX, IEnumerable<double> _dataY);

        double GetValue(double x);

        double GetTrendValue(double x);
 
    }
}
