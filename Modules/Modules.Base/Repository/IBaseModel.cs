
using System;

namespace Modules.Base.Repository
{
    public interface IBaseModel
    {
        int Id { get; set; }
        byte[] TimeStamp { get; set; }
    }
}
