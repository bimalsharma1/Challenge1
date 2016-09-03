using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos.OLO.Vouchers.Repository
{
    /* Author: Bimal Sharma
     * Description: Interface for data provider path 
     * 
     */
    public interface IPathProvider
    {
        string MapPath(string path);
    }
}
