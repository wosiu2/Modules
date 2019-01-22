using MathTools.BaseModel;
using Modules.Base.Model;
using System;
using System.Collections.Generic;

namespace Modules.Base.Manager
{
   public interface IDataFilter
    {
        IEnumerable<Point> GetFilteredDataByEpsilon();

        IEnumerable<Point> GetFilteredDataByStress();

        IEnumerable<Point> GetFilteredDataByStressRelative();
    }
}
