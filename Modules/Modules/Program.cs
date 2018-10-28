using Modules.Base.Model;
using Modules.Logic;
using Modules.Manager;


namespace Modules
{
    class Program
    {
        static void Main(string[] args)
        {
            var _soilSample = new SoilSample()
            {
                Weight = 18.522,
                Compaction=98,
                SolidWeight=26,
                SieveParameters=new SieveParameters()
                {
                    D10=0.17,
                    D30=0.3,
                    D50=0.41,
                    D60=0.47,
                    FineGrains=0.03
                }

            };
            var _soilParameters = new SDMBasedParametersManager();

            _soilParameters.SoilSample = _soilSample;

            var _model=new DuncanSoilModel(_soilParameters, _soilParameters);
             _model.AtmosphericPressure = 100;
             _model.ConfiningPressure = 30.87;

            

            var modules = new ModulesCalculator(_model);

            double secant = modules.GetSecantModulus(.5);
            double tangent = modules.GetTangentModulus(.5 );

        }
    }
}
