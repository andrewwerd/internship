using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Proxy
{
    interface IGetCarInfo
    {
        List<string> CarsInfo(IAccess entity);
    }
}
