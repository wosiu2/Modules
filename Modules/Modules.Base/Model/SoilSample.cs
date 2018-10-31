
using System.Collections.Generic;

namespace Modules.Base.Model
{
    public class SoilSample : BaseModel

    {
        public SieveParameter SieveParameters { get; set; }

        public double Weight { get; set; }
        public double SolidWeight { get; set; }
        public double Compaction { get; set; }

        public ICollection<SieveMesh> TestResults{get;set;}
    }
}
