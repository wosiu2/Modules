
using Modules.Base.Model;
using System.Collections.Generic;

namespace Modules.Base.Repository
{
   public  interface ISoilSampleRepository
    {
        IEnumerable<SoilSample> GetAllForUser(int userId);


    }
}
