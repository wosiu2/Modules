
namespace Modules.Base.Manager
{
    public interface IStrengthParameters
    {
        double FrictionAngle { get; }
        double IncrementFrictionAngle { get; }
        double Cohesion { get; }
        double FrictionAngleRadians { get;}
        double IncrementFrictionAngleRadians { get; }


    }
}
