using MathTools.BaseModel;
using MathTools.Estimator;
using MathTools.Estimator.Abstraction;
using MathTools.NonlinearSolver;
using MathTools.NonlinearSolver.Abstraction;
using Modules.Base.Manager;
using Modules.Base.Model;
using System.Collections.Generic;
using System.Linq;
namespace Modules.Manager
{
    public class SieveParametersManager : ISieveParametersManager
    {
        public SoilSample Soil { get; set; }
        public double FinesSize { get; set; }
        private IEstimator<double,Point> _estimator { get; set; }
        private IDerivative<double> _derivative;
        public bool WithUpdate { get; set; }
        public SieveParametersManager(SoilSample _soil)
        {
            Soil = _soil;
            FinesSize = 0.063;
            _estimator = new TwoPointEstimator();          
            _derivative = new Derivative(x=>_estimator.Estimate(x),0.00001);
            WithUpdate = true;

        }

        public SieveParameter GetSieveParameters()
        {
            var param = new SieveParameter();
            //param.FineGrains

            if (IsValid())
            {
                param.FineGrainSize = FinesSize;
                param.FineGrainAmount = _estimator.Estimate(FinesSize);

                var data = GetPointsAmountDependant();
                _estimator.EstimatorData = data;

                param.D10 = _estimator.Estimate(0.1);
                param.D30 = _estimator.Estimate(0.3);
                param.D50 = _estimator.Estimate(0.5);
                param.D60 = _estimator.Estimate(0.6);
                if (Soil.SieveParameter!=null)
                {
                    Soil.SieveParameter.D10 = param.D10;
                    Soil.SieveParameter.D30 = param.D30;
                    Soil.SieveParameter.D50 = param.D50;
                    Soil.SieveParameter.D60 = param.D60;
                    Soil.SieveParameter.FineGrainAmount = param.FineGrainAmount;
                    Soil.SieveParameter.FineGrainSize = param.FineGrainSize;
                }

            }
            return param;
        }

        public bool IsValid()
        {
            var data = GetPointsSizeDependant();
            _estimator.EstimatorData = data;

            foreach (Point p in data)
            {
                if (_derivative.GetFirstDerivative(p.X) < 0) return false;
            }
            return true;
        }

        public IEnumerable<Point> GetPointsSizeDependant()
        {
            return Soil.TestResult.OrderBy(n => n.Size).Select(n => new Point() { Y = n.Amount, X = n.Size });
        }

        public IEnumerable<Point> GetPointsAmountDependant()
        {
            return Soil.TestResult.OrderBy(n => n.Amount).Select(n=>new Point() { X=n.Amount,Y=n.Size});
        }

        public double EstimateGrain(double size)
        {

            var data = GetPointsSizeDependant();
            _estimator.EstimatorData = data;

            return _estimator.Estimate(size);
        }
    }

}
