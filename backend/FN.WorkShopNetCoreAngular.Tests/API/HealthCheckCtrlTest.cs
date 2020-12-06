
using FN.WorkShopNetCoreAngular.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FN.WorkShopNetCoreAngular.Tests.API
{
    [TestClass]
    public class HealthCheckCtrlTest
    {

        [TestMethod]
        public void VerboGetDeveraRetornarStatusCode200()
        {
            var ctrl = new HealthCheckController();

            var result = ctrl.Get() as StatusCodeResult;

            Assert.AreEqual(200, result.StatusCode);
        }

    }
}