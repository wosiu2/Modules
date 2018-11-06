using Modules.Base.Model;
using Modules.Base.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Modules.Repository
{
    public class SoilSampleRepository : BaseRepository<SoilSample, ModulesDbContext>,ISoilSampleRepository
    {
        public override SoilSample Get(int id)
        {
            var sample=Context.SoilSamples
                
                .Where(n => n.Id == id)
                .SingleOrDefault();

            /*sample.SieveParameter.FineGrain = Context.SieveParameters
                .Include(n=>n.FineGrain)
                .Where(n => n.Id == sample.SieveParameter.Id)
                .SingleOrDefault()
                .FineGrain;*/
                
            return sample;
        }

        public IEnumerable<SoilSample> GetAllForUser(int userId)
        {
            return GetAll().Where(n => n.UserId == userId);
        }
        public IEnumerable<SoilSample> GetAllForUserEager(int userId)
        {
            return _context.SoilSamples.Include(n=>n.TestResult).Where(n => n.UserId == userId);
        }

        public SoilSample GetEager(int id)
        {
            return _context.SoilSamples.Include(n => n.TestResult).Where(n => n.Id == id).SingleOrDefault();
        }

        public override void Delete(SoilSample entity)
        {
            
            _context.SieveMeshes.RemoveRange(entity.TestResult);
            _context.SieveParameters.Remove(entity.SieveParameter);
            base.Delete(entity);
        }

    }
}
