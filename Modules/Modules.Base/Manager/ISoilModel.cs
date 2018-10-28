
namespace Modules.Base.Manager
{
    public interface ISoilModel
    {
        double GetDeviatoricStress(double eps);
        double GetFailureStress();
        double GetUltimateStress();
        double GetInitialModulus();
    }
}
