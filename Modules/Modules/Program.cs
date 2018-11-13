﻿using MathTools.BaseModel;
using MathTools.Estimator;
using Modules.Base.Model;
using Modules.Logic;
using Modules.Manager;
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
            var _soilSample = new SoilSample();
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

            /*
                        var plast = new PlasticityClass("S", true);

                        var grade = new GradeClass("S",6);

                        var d=grade.GetClass(_soilSample);

                        var p = plast.GetClass(new Base.Model.NonDb.AttenbergLimits() {PlasticLimit=20,LiquidLimit=20 });
                        */
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
            repo.Complete();
        }
    }
}
