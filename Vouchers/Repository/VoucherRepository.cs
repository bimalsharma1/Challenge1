using System;
using System.IO;
using Dominos.OLO.Vouchers.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Linq;

namespace Dominos.OLO.Vouchers.Repository
{
    /* Author: Bimal Sharma
     * Description: Inherits IVoucherRepository interface. Defines all the methods to return data to the action calls
     * These provide data to return for the end point calls
     */
    public class VoucherRepository : IVoucherRepository
    {
        private string _filename = ConfigurationManager.AppSettings["datasourcejson"];

        public static string fullpathname;

        public List<Voucher> _vouchers;

        public VoucherRepository(IPathProvider provider)
        {

            fullpathname = string.Concat(provider.MapPath("App_Data/"), this._filename);
            var text = File.ReadAllText(fullpathname);
            _vouchers = JsonConvert.DeserializeObject<List<Voucher>>(text);            
        }

        public List<Voucher> GetVouchers(int count)
        {
           return count == 0 ?  _vouchers :  _vouchers.Take(count).ToList();
        }

        public Voucher GetVouchersById(Guid id)
        {
            Voucher voucher = null;
            voucher = _vouchers.Find(x => x.Id == id);
            return voucher;
        }

        public List<Voucher> GetVouchersByName(string name)
        {
            List<Voucher> vouchers = new List<Voucher>();
            vouchers = _vouchers.FindAll(x => x.Name.Replace(" ", "").Equals(name.Replace(" ", "")));
            return vouchers ?? null;
        }

        public Voucher GetCheapestVoucherByProductCode(string productCode)
        {
            Voucher voucher = null;
            voucher = _vouchers.FindAll(x => x.ProductCodes.Contains(productCode)).OrderBy(x => x.Price).FirstOrDefault();
            return voucher;
        }

        public List<Voucher> GetVouchersByNameSearch(string name)
        {
            return _vouchers.FindAll(x => x.Name.Contains(name));
        }
    }
}