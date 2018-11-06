using Modules.Base.Manager;
using Modules.Base.Model;
using Modules.Base.Model.NonDb;


namespace Modules.Manager.USCS
{
    public class BasicClassificationManager
    {

        public SoilSample SoilSample { get; set; }
        public AttenbergLimits AttenbergLimits { get; set; }

        public BasicClassificationManager(SoilSample soil,AttenbergLimits limits)
        {
            SoilSample = soil;
            AttenbergLimits = limits;
        }

        public string Classify()
        {
            var gravels = new SizeClass(SoilSample, 0.075,new IClassify<string>[]{new GradeClass(SoilSample,"G",4),
                new HybrydClass(SoilSample,AttenbergLimits,"G",4) , new GradeClass(SoilSample,"G", 4) },
                new double[] { 0.05, 0.12 });

            var sands = new SizeClass(SoilSample, 0.075, new IClassify<string>[]{new GradeClass(SoilSample,"S",6),
                new HybrydClass(SoilSample,AttenbergLimits,"S",6) , new GradeClass(SoilSample,"S", 6) },
                new double[] { 0.05, 0.12 });

            var course = new SizeClass(SoilSample, 4.75, new IClassify<string>[] { gravels, sands }, 
                new double[] { 0.5 });

            return course.GetClass();
        }

    }
}
