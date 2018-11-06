using Modules.Base.Model;
using Modules.Manager;
using Modules.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Modules.WebGUI.Controllers
{
    public class SieveController : Controller
    {
        // GET: Sieve
        public ActionResult SieveSamples()
        {
            var repo = new SoilSampleRepository();
            var samples = repo.GetAllForUser(1);
            /*  foreach(var s in samples)
              {
                  if (s.SieveParameter == null) repo.Delete(s);
              }
              repo.Complete();*/

            return View(samples);
        }

        public ActionResult DeleteSample(int id)
        {
            var repo = new SoilSampleRepository();
            var sample = repo.GetEager(id);
            repo.Delete(sample);
            repo.Complete();
            return RedirectToAction("SieveSamples");
        }

        public ActionResult EditSample(int id)
        {
            return RedirectToAction("SieveSamples");
        }

        public ActionResult ShowSample()
        {
            return RedirectToAction("SieveSamples");
        }


        public ActionResult AddSample(int? id)
        {
 
            
            if (id != null)
            {
                var repo = new SoilSampleRepository();
                return View(repo.GetEager((int)id));
            }
            return View(new SoilSample());
            /*else
            {

                return View(sample);
            }*/

        }

        [HttpPost]
        public ActionResult AddSample(FormCollection e,string submit)
        {

            var repo = new SoilSampleRepository();
            if (submit=="Add")
            {
                var i = int.Parse(e["id"]);
                if (i == 0)
                {
                    var sample = new SoilSample()
                    {
                        SieveParameter = new SieveParameter() ,
                        TestResult = new List<SieveMesh>(),

                        UserId = 1
                    };
                    repo.Add(sample);
                    repo.Complete();
                    i = sample.Id;
                }
                var sam = repo.GetEager(i);
                if (double.TryParse(e["Size"], out double size) && double.TryParse(e["Amount"], out double amount))
                {
                    sam.Name = e["Name"];
                    sam.TestResult.Add(new SieveMesh() { Size = size, Amount = amount / 100 });
                    repo.Complete();
                }
         

                return RedirectToAction("AddSample", new { id = sam.Id });
            }


            return RedirectToAction("SaveSample",new {id= e["id"] });
        }

        public ActionResult SaveSample(int id)
        {
            var repo = new SoilSampleRepository();
            var sample = repo.GetEager(id);
            var _parameterManager = new SieveParametersManager(sample);

            if (_parameterManager.IsValid())
            {
                _parameterManager.GetSieveParameters();
                /*
                param.Id = sample.SieveParameter.Id;
                param.FineGrain.Id = sample.SieveParameter.FineGrain.Id;

                sample.SieveParameter = param;
                //repo.Delete(sample);
                */
                repo.Complete();

            }
            else
            {
                repo.Delete(sample);
                repo.Complete();
            }
            
            return RedirectToAction("SieveSamples");
        }

        public ActionResult GetGraph(int? id)
        {
            if (id != null)
            {
                var repo = new SoilSampleRepository();
                var sample=repo.GetEager((int)id);

                var dataSize = sample.TestResult.OrderBy(n => n.Size).Select(n => n.Size).ToArray();
                var dataAmount = sample.TestResult.OrderBy(n => n.Size).Select(n => n.Amount).ToArray();

                var chart = new Chart(width: 500, height: 500).AddSeries(chartType: "line", xValue: dataSize, yValues: dataAmount).Write();

            }
            return null;
        }
    }


}
