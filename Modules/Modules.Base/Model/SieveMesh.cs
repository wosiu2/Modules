
using Modules.Base.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Base.Model
{
    public class SieveMesh: IBaseModel
    {

        public int Id { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public double Size { get; set; }
        public double Amount { get; set; }

        [ForeignKey("SoilSample")]
        public int SoilSampleId { get; set; }
        public virtual SoilSample SoilSample { get; set; }


        
    }
}
