using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiLab;
using WebApiLab.Controllers;
using WebApiLab.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Planet planet = WebApi1Controller.ParsePlanet("Name=Saturnus&Size=123");
            Assert.AreEqual("Saturnus", planet.Name);
            Assert.AreEqual(125, planet.Size);

            //var x = new Hej();

        }
    }
}
