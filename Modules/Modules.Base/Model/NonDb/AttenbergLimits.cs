
namespace Modules.Base.Model.NonDb
{
    public class AttenbergLimits
    {
        public double PlasticLimit { get; set; }
        public double LiquidLimit { get; set; }
        public double PlasticityIndex { get => LiquidLimit - PlasticLimit; }
    }
}
