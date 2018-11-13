using Modules.Base.Manager;
using Modules.Base.Model;


namespace Modules.Manager.USCS
{
    public class GradeClass : IClassify<string>
    {
        private string _mainClass;
        private double _uniformity;
        private SoilSample _soil;

        public GradeClass(SoilSample soil,string mainClass, double uniformity)
        {
            _mainClass = mainClass;
            _uniformity = uniformity;
            _soil = soil;

        }

        public string GetClass()
        {
            var sm = new SieveParametersManager(_soil) { WithUpdate = false };
            var coef = new SieveCoefficients() { SieveParameters = sm.GetSieveParameters() };

            if (coef.GetUniformity() >= _uniformity && coef.GetCurvature() <= 3 && coef.GetCurvature() >= 1)
            {
                return _mainClass + "W";
            }
            return _mainClass + "P";
        }
    }
}
