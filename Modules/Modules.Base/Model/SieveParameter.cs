﻿
using Modules.Base.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Base.Model
{
    public class SieveParameter:IBaseModel
    {
        [ForeignKey("SoilSample")]
        public int Id { get; set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        // public int SieveParameterId { get; set; }

        public double D10 { get; set; }
        public double D30 { get; set; }
        public double D50 { get; set; }
        public double D60 { get; set; }

        public virtual SoilSample SoilSample { get; set; }

        public virtual SieveMesh FineGrain { get; set; }
    }

}
