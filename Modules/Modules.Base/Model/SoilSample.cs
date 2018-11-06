
using Modules.Base.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Base.Model
{
    public class SoilSample :IBaseModel

    {
        
        public int Id { get; set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        public double Weight { get; set; }
        public double SolidWeight { get; set; }
        public double Compaction { get; set; }
        public string Name { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual SieveParameter SieveParameter { get; set; }

        public ICollection<SieveMesh> TestResult{get;set;}
    }
}
