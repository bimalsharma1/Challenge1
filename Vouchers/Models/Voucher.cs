using System;

namespace Dominos.OLO.Vouchers.Models
{
    /* Author: Bimal Sharma
     * Description: voucher model to serialise json file and send stream of data through end point calls
     * 
     */
    public class Voucher
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; } //double type is used as it is 64 bit compared to 32 bit float

        public string ProductCodes { get; set; }
    }
}