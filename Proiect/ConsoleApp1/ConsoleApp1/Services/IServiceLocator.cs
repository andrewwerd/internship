using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect.Services
{
    interface IServiceLocator
    {
        T GetService<T>();
    }
}
