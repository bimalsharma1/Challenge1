using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominos.OLO.Vouchers.Repository
{
    /* Author: Bimal Sharma
     * Description: Class to return path of source data 
     * 
     */
    public class SearchPathProvider : IPathProvider
    {
        public string MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath("~/" + path);
        }
    }
}