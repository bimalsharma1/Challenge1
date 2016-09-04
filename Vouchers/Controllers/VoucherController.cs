using System;
using System.Collections.Generic;
using System.Web.Http;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;
using System.Net;
/*
* Author: Bimal Sharma
* Description: Main controller and actions of the system
* includes routes for all the httpget
*/
namespace Dominos.OLO.Vouchers.Controllers
{

    public class VoucherController : ApiController
    {
        private readonly IVoucherRepository Repository;


        //constructor
        public VoucherController(IVoucherRepository VouRepository)
        {
            Repository = VouRepository;
        }

        //Get all the vouchers. If no parameter is passed int he router then return everything. 
        [Route("api/voucher/{count:int?}")]
        public Voucher[] Get(int count = 0)
        {
            var vouchers = Repository.GetVouchers(count);
            //The following throw can be uncommented to test error handling
            //throw new InvalidOperationException("This exception was thrown in an action method.");
            return vouchers.ToArray(); //use to a non .net type like list in case non microsoft systems are reading info
        }


        //Get voucher by filtering the GUID
        [Route("api/voucher/{id:Guid}")]
        public Voucher GetVoucherById(Guid id)
        {
            Voucher voucher = Repository.GetVouchersById(id);
            return voucher;
        }

        //filter by name
        [HttpGet]
        [Route("api/voucherbyname/{name}")]
        public Voucher[] GetVouchersByName(string name)
        {
            var vouchers = Repository.GetVouchersByName(name);
            return vouchers.ToArray();
        }

        //search the collection by name
        [HttpGet]
        [Route("api/vouchersearchbyname/{search}")]
        public Voucher[] GetVouchersByNameSearch(string search)
        {
            var vouchers = Repository.GetVouchersByNameSearch(search);
            return vouchers.ToArray();
        }

        //search collection by product code
        [HttpGet]
        [Route("api/voucherbyproductcode/{productcode}")]
        public Voucher GetCheapestVoucherByProductCode(string productCode)
        {
            Voucher voucher = Repository.GetCheapestVoucherByProductCode(productCode);
            return voucher;
        }
    }
}