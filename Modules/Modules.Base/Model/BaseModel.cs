using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Base.Model
{
    public abstract class BaseModel
    {
        [Index(IsUnique = true)]
        [Required]
        public int Id { get; set; }
        //public DateTime TimeStamp { get; set; }
    }
}
