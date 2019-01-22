using MathTools.BaseModel;
using System.Collections.Generic;



namespace Modules.Base.Model
{
    public class TriaxialTest
    {
        public double ConfiningPressure { get; set; }
        public IEnumerable<Point> TestResults { get; set; }
    }
}
