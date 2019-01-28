using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLab.Models;

namespace WebApiLab.Controllers
{
    [Route("webapi1")]
    public class WebApi1Controller : Controller
    {
        [Route("AddPlanet")]
        public IActionResult AddPlanet()
        {
            string formContent = "";
            using(StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                formContent = reader.ReadToEndAsync().Result;
            }

            Planet planet = ParsePlanet(formContent);

            return Ok("Ny planet " + planet.Name + " skapad med storleken " + planet.Size.ToString());
        }

        private Planet ParsePlanet(string formContent)
        {
            //Output: Planet=Pluto&Size=12

            string[] formContentArray = formContent.Split('&');

            //Nackdel med denna lösning då den inte funkar om man ändrar i formuläret eller byter plats på grejerna tex
            Planet planet = new Planet
            {
                Name = formContentArray[0].Remove(0, 7),
                Size = int.Parse(formContentArray[1].Remove(0, 5))
            };

            return planet;
        }

        [Route("GetPlanet")]
        public IActionResult GetPlanet()
        {

            //Output: "?Planet=Mars&Size=125"
            string[] queryStringArray = Request.QueryString.Value.Split('&');

            Planet planet = new Planet
            {
                Name = queryStringArray[0].Remove(0, 8),
                Size = int.Parse(queryStringArray[1].Remove(0, 5))
            };


            return Ok("Söker i databasen efter planeter med namn " + planet.Name + " och storlek " + planet.Size.ToString());
        }
    }
}
