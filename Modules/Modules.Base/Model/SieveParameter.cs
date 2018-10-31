
namespace Modules.Base.Model
{
    public class SieveParameter:BaseModel
    {
        public SieveMesh FineGrains { get; set; }
        public double D10 { get; set; }
        public double D30 { get; set; }
        public double D50 { get; set; }
        public double D60 { get; set; }
    }
}
