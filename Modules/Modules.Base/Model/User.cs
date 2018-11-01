
using Modules.Base.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Base.Model
{
    public class User:IBaseModel
    {
        //[ForeignKey("Sample")]
        public int Id { get; set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        // public int UserId { get; set; }

        [Index(IsUnique =true)]
        [Required]
        [StringLength(30)]
        public string Login { get; set; }
        [Required]
        public string Passwd { get; set; }

        public ICollection<SoilSample> Sample { get; set; }
    }
}
