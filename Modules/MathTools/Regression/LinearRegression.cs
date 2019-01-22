using MathTools.Regression.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace MathTools.Regression
{
    public class LinearRegression: IRegression
    {
        public double _a, _b;

        public void Update(IEnumerable<double> _dataX, IEnumerable<double> _dataY)
        {
            double _top = 0, _bottom = 0;

            double diffX = 0;
            double diffY = 0;

            var _averageX = _dataX.Average();
            var _averageY = _dataY.Average();

            var _elements = _dataX.Zip(_dataY, (x, y) => new { X = x, Y = y });

            foreach (var element in _elements)
            {
                diffX = element.X - _averageX;
                diffY = element.Y - _averageY;

                _bottom += diffX * diffX;
                _top += diffY * diffX;
            }

            _a = _top / _bottom;
            _b = _averageY - _a* _averageX;
        }

        public double GetValue(double x)
        {
            return _a * x + _b;
        }
        public double GetTrendValue(double x)
        {
            return _a * x;
        }
    }




}
