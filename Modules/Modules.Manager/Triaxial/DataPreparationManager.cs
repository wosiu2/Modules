using MathTools.BaseModel;
using Modules.Base.Manager;
using System.Collections.Generic;
using System.Linq;


namespace Modules.Manager.Triaxial
{
    public class DataPreparationManager : IDataFilter
    {
        private IEnumerable<Point> _baseList;
        private Point _maxPoint;

        public DataPreparationManager(IEnumerable<Point> baseList)
        {
            _baseList = baseList;

            _maxPoint = _baseList
                .OrderBy(n=>n.Y)
                .LastOrDefault();
        }

        public IEnumerable<Point> GetFilteredDataByEpsilon()
        {
            return _baseList.Where(n => n.X <= _maxPoint.X).ToList();
        }

        public IEnumerable<Point> GetFilteredDataByStress()
        {
            return _baseList.Where(n => n.X <= _maxPoint.X).Select(n=>new Point() {X=n.Y,Y=n.X}).ToList();
        }

        public IEnumerable<Point> GetFilteredDataByStressRelative()
        {
            return _baseList.Where(n => n.X <= _maxPoint.X).Select(n => new Point() { X = n.Y/ _maxPoint.Y, Y = n.X }).ToList();
        }
    }
}
