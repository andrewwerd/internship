using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Proxy
{
    class Inspector : IAccess
    {
        public string Name { get; set; }
        public string Access
        {
            get => "Inspector";
        }
    }
}
