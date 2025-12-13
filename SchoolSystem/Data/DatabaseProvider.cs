using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data
{
    public static class DatabaseProvider
    {
        private static SchoolSystemContext? _context;

        public static SchoolSystemContext Context
        {
            get
            {
                if (_context == null)
                    _context = new SchoolSystemContext();

                return _context;
            }
        }
    }
}
