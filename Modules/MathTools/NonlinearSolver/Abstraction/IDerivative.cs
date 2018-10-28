
namespace MathTools.NonlinearSolver.Abstraction
{
    public interface IDerivative<T>
    {
        T GetFirstDerivative(T point);
        T GetSecondDerivative(T point);
    }
}
