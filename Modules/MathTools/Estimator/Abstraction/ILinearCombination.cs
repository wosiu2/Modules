
using System.Collections.Generic;

namespace MathTools.Estimator.Abstraction
{
    public interface ILinearCombination<T,U>
    {
        T GetLinearCombination(IEnumerable<U> a,IEnumerable<T> x);
    }
}
