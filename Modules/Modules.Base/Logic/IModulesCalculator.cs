
namespace Modules.Base.Logic
{
    public interface IModulesCalculator
    {
        double GetTangentModulus(double ratio);
        double GetSecantModulus(double ratio);
    }
}
