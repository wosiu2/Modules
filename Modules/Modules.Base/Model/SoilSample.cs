
namespace Modules.Base.Model
{
    public class SoilSample:BaseModel

    {
        public SieveParameters SieveParameters { get; set; }

        public double Weight { get; set; }
        public double SolidWeight { get; set; }
        public double Compaction { get; set; }
    }
}
