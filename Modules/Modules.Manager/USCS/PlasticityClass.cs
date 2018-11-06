using Modules.Base.Manager;
using Modules.Base.Model.NonDb;


namespace Modules.Manager.USCS
{
    public class PlasticityClass : IClassify<string>
    {

        private string _mainClass;
        private bool _reduced;
        private AttenbergLimits _attenberg;

        public PlasticityClass( AttenbergLimits attenberg ,string mainClass,bool reduced=false)
        {
            _mainClass = mainClass;
            _reduced = reduced;
            _attenberg = attenberg;
        }


        public string GetClass()
        {
            if(!IsBelowUpperBound(_attenberg)) return "Out of scope";

            if (_attenberg.PlasticityIndex>7&& IsAboveLowerBound(_attenberg))
            {
                return _mainClass + "C";
            }
            if (_attenberg.PlasticityIndex < 4|| !IsAboveLowerBound(_attenberg))
            {
                return _mainClass + "M";
            }

            if (_attenberg.PlasticityIndex >= 4&& _attenberg.PlasticityIndex <= 7&& IsAboveLowerBound(_attenberg))
            {
                if (_reduced)
                {
                    return _mainClass + "C";
                }
                return _mainClass + "C-" + _mainClass + "M";
            }

             return "Out of scope";

            
            
        }


        bool IsAboveLowerBound(AttenbergLimits input)
        {
            return input.PlasticityIndex >= 0.73 * (input.LiquidLimit - 20);
        }

        bool IsBelowUpperBound(AttenbergLimits input)
        {
            return input.PlasticityIndex <= 0.9 * (input.LiquidLimit-8);
        }
    }
}
