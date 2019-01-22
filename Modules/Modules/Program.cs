using MathTools.BaseModel;
using MathTools.Estimator;
using MathTools.Regression;
using Modules.Base.Model;
using Modules.Logic;
using Modules.Manager;
using Modules.Manager.Triaxial;
using Modules.Manager.USCS;
using Modules.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace Modules
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  var _soilSample = new SoilSample();
              _soilSample.TestResult = new List<SieveMesh>();
              _soilSample.TestResult.Add(new SieveMesh() { Amount = 0.06, Size = 0.063 });
              _soilSample.TestResult.Add(new SieveMesh() { Amount = 0.18, Size = 0.125 });
              _soilSample.TestResult.Add(new SieveMesh() { Amount = 0.25, Size = 0.25 });
              _soilSample.TestResult.Add(new SieveMesh() { Amount = 0.45, Size = 0.5 });
              _soilSample.TestResult.Add(new SieveMesh() { Amount = 0.60, Size = 1.0 });
              _soilSample.TestResult.Add(new SieveMesh() { Amount = 0.80, Size = 4.0 });
              _soilSample.TestResult.Add(new SieveMesh() { Amount = 1.0, Size = 8 });
              var s = new SieveParametersManager(_soilSample);

              _soilSample.SieveParameter = s.GetSieveParameters();
              _soilSample.Weight = 18.5;
              _soilSample.Compaction = 98;
              _soilSample.SolidWeight = 26;


                          var plast = new PlasticityClass("S", true);

                          var grade = new GradeClass("S",6);

                          var d=grade.GetClass(_soilSample);

                          var p = plast.GetClass(new Base.Model.NonDb.AttenbergLimits() {PlasticLimit=20,LiquidLimit=20 });

              var cla = new BasicClassificationManager(_soilSample,new Base.Model.NonDb.AttenbergLimits() { PlasticLimit=20,LiquidLimit=20});

              var fsd = cla.Classify();
              var _soilParameters = new SDMBasedParametersManager();

              _soilParameters.SoilSample = _soilSample;

              var _model = new DuncanSoilModel(_soilParameters, _soilParameters);
              _model.AtmosphericPressure = 100;
              _model.ConfiningPressure = 50;



              var modules = new ModulesCalculator(_model);

              double secant = modules.GetSecantModulus(.2);
              double tangent = modules.GetTangentModulus(.2);

              var repoU = new UserRepository();
              repoU.Add(new User() { Login = "wosiu", Passwd = "sss" ,Expire=200});
              repoU.Complete();

              _soilSample.UserId = 1;
              _soilSample.Name = "dadssdasadsaa";


              var repo = new SoilSampleRepository();
              //SoilSample usr=repo.Get(1);

              repo.Add(_soilSample);
              repo.Complete();*/

            

            //var res = par.ResultantFrictionAngle(589, 100);

            var listA = new Point[] {
                new Point() {X=1,Y=4274.749 },
            };
            var listB = new Point[] {
                new Point() {X=1,Y=7584.23 },
            };

            var listC = new Point[] {
                new Point() {X=1,Y=10686.87 },
            };

            var listOfTests = new TriaxialTest[] {
                new TriaxialTest() {ConfiningPressure=861.84,TestResults=listA },
                new TriaxialTest() {ConfiningPressure=1723.689,TestResults=listB },
                new TriaxialTest() {ConfiningPressure=2930.27,TestResults=listC }
            };
            var par = new MohrCohesionlessParameters(listOfTests);
            var ddd = par.FrictionAngle;

            var listD = new Point[] {
                new Point() {X=1,Y=1 },
                new Point() {X=2,Y=4 },
                new Point() {X=3,Y=6 },
                new Point() {X=4,Y=8 },
                new Point() {X=5,Y=6 },
                new Point() {X=6,Y=4 },
            };

            var datafilter = new DataPreparationManager(listD);

            var fd = datafilter.GetFilteredDataByEpsilon();
            var fdd = datafilter.GetFilteredDataByStress();
            var fddd = datafilter.GetFilteredDataByStressRelative();
        }
    }
}
