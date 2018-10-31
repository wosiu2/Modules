
using Modules.Base.Model;

namespace Modules.Base.Manager
{
    public interface ISieveParametersManager
    {
        SieveParameter GetSieveParameters();
        bool IsValid();
    }
}
