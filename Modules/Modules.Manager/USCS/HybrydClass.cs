using Modules.Base.Manager;
using Modules.Base.Model;
using Modules.Base.Model.NonDb;

namespace Modules.Manager.USCS
{
    public class HybrydClass : IClassify<string>
    {
        private AttenbergLimits _attenberg;
        private string _mainClass;
        private double _uniformity;
        private SoilSample _soil;

        public HybrydClass(SoilSample soil, AttenbergLimits attenberg , string mainClass, double uniformity)
        {
            _mainClass = mainClass;
            _uniformity = uniformity;
            _soil = soil;
            _attenberg = attenberg;
        }

        public string GetClass()
        {
            var grade = new GradeClass(_soil, _mainClass, _uniformity);
            var plasticity = new PlasticityClass( _attenberg, _mainClass,reduced:true);

            return grade.GetClass()+"-"+ plasticity.GetClass();
        }
    }
}
