using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class EmailRepository
    {
        private List<string> _context = new List<string>();

        public void Add(string email)
        {
            _context.Add(email);
        }
        public virtual bool TryFind(string email)
        {
            return _context.FirstOrDefault(x => x == email) != null;
        }
    }
}
