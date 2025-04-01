using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR6_2
{
    class Core
    {
        private static UnitTestEntities _UnitTestEntities;

        public static UnitTestEntities DB = GetContext();

        public static UnitTestEntities GetContext()
        {
            if (_UnitTestEntities == null)
            {
                _UnitTestEntities = new UnitTestEntities();
            }
            return _UnitTestEntities;
        }
    }
}
