using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominos.OLO.Vouchers.Repository;
using System.IO;

namespace Dominos.OLO.Vouchers.Tests.Unit
{
        public class TestPathProvider : IPathProvider
        {
            public string MapPath(string path)
            {
                path = path + @"\";
                return path;
            }
        }
}
