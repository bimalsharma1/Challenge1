using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominos.OLO.Vouchers.Models;

namespace Dominos.OLO.Vouchers.Repository
{
    /* Author: Bimal Sharma
     * Description: Interface to act as a contract to define the class Voucher repository
     * 
     */
    public interface IVoucherRepository
    {
        List<Voucher> GetVouchers(int count);
        Voucher GetVouchersById(Guid id);
        List<Voucher> GetVouchersByName(string name);
        Voucher GetCheapestVoucherByProductCode(string productCode);
        List<Voucher> GetVouchersByNameSearch(string name);
    }
}
