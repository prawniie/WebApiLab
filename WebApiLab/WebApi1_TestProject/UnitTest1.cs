using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiLab.Controllers;
using WebApiLab.Models;

namespace WebApi1_TestProject
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

        }
    }
}
