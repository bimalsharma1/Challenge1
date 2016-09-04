using System;
using System.Collections.Generic;
using Dominos.OLO.Vouchers.Tests;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;
using Dominos.OLO.Vouchers.Controllers;
using NSubstitute;
using NUnit.Framework;
using System.Configuration;
using System.Web;

namespace Dominos.OLO.Vouchers.Tests.Unit
{
   /* Author: Bimal Sharma
   * Description: Controller for all the performance tests
   */
    [TestFixture]
    public class VoucherControllerPerformanceTests
    {
        private List<Voucher> _vouchers = new List<Voucher>();
        private VoucherRepository vp;
        private VoucherController _controller;
        [SetUp]
        public void Setup()
        {
            vp = new VoucherRepository(new TestPathProvider());
            _controller = new VoucherController(vp);
        }

        [Test]
        public void Get_ShouldBePerformant()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 1000; i++)
            {
                _controller.Get();
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 20000);
        }

        [Test]
        public void Get_ShouldBePerformantWhenReturningASubset()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 100000; i++)
            {
                _controller.Get(1000);
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 20000);
        }

        [Test]
        public void GetCheapestVoucherByProductCode_ShouldBePerformant()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 100; i++)
            {
                _controller.GetCheapestVoucherByProductCode("P007D");
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 20000);
        }
    }
}