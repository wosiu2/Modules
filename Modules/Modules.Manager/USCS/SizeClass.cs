using Modules.Base.Manager;
using Modules.Base.Model;
using System.Collections.Generic;
using System.Linq;

namespace Modules.Manager.USCS
{
    public class SizeClass : IClassify<string>
    {
        private IEnumerable<IClassify<string>> _classifies;
        private IEnumerable<double> _ranges;
        private SoilSample _soil;
        private double _grain;

        public SizeClass(SoilSample soil, double grain, IEnumerable<IClassify<string>> classifies, IEnumerable<double> ranges)
        {
            var a = ranges.Count();
            var b = classifies.Count();
            if (ranges.Count()+1== classifies.Count())
            {
                _classifies = classifies;
                _ranges = ranges;
                _soil = soil;
                _grain = grain;
            }
            else
            {
                throw new System.Exception();
            }
            

        }

        public virtual string GetClass()
        {
            var amount = GetGrain(_soil, _grain);
            return StartClassification(_soil, amount);
        }

        public string StartClassification(SoilSample input,double determinant)
        {
            var actions = _classifies.Zip(_ranges, (x, y) => new { range = y, actionClass = x }).OrderBy(n => n.range);

            foreach (var action in actions)
            {
                if (determinant < action.range)
                {
                    return action.actionClass.GetClass();
                }
            }
            return _classifies.Last().GetClass();
        }

        /*
        public double GetFines(SoilSample input)
        {
            if (input.SieveParameter.FineGrainSize != 0.075)
            {
                var sieveManager = new SieveParametersManager(input) { WithUpdate = false, FinesSize = 0.075 };
                return sieveManager.GetSieveParameters().FineGrainAmount;
            }
            else
            {
                return input.SieveParameter.FineGrainAmount;
            }
        }*/

        public double GetGrain(SoilSample input , double grain)
        {
            var sieveManager = new SieveParametersManager(input) { WithUpdate = false, FinesSize = 0.075 };  
            return sieveManager.EstimateGrain(grain);
        }
    }
}
