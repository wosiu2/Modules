using MathTools.BaseModel;
using MathTools.Estimator.Abstraction;
using Modules.Base.Manager;
using Modules.Base.Model;
using System.Collections.Generic;


namespace Modules.Manager.Triaxial
{
    public class TransformationDataManager
    {
        private IEstimator<double, Point> _estimator;
        private IDataFilter _baseData;

        public TransformationDataManager(IEstimator<double, Point> estimator, IDataFilter baseData)
        {
            _estimator = estimator;
            _baseData = baseData;
        }

        public IEnumerable<double> ResolveStrains(TriaxialTest _traxialTest, double[] pointsOfIntrest)
        {
            var list = new List<double>();

            foreach (var point in pointsOfIntrest)
            {
                _estimator.EstimatorData = _baseData.GetFilteredDataByStressRelative();
                list.Add( _estimator.Estimate(point));
            }
            return list;

        }
        public IEnumerable<double> ResolveStreses(TriaxialTest _traxialTest, double[] pointsOfIntrest)
        {
            var list = new List<double>();

            var listOfStrains = ResolveStrains(_traxialTest, pointsOfIntrest);

            foreach (var strain in listOfStrains)
            {

                _estimator.EstimatorData = _baseData.GetFilteredDataByEpsilon();
                list.Add(_estimator.Estimate(strain));
            }

            return list;
        }


    }
}
