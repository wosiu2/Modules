
namespace Modules.Base.Manager
{
    public interface IStrengthParameters
    {
        double FrictionAngle { get; }
        double Cohesion { get; }

        double GetFrictionAngleRad();
    }
}
