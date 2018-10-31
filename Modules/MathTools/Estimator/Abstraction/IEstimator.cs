

using System.Collections.Generic;

namespace MathTools.Estimator.Abstraction
{
    public interface IEstimator<T,U>
    {
        IEnumerable<U> EstimatorData { get; set; }

        T Estimate(T x);
    }
}
