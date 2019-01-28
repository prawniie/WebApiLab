using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLab.Controllers
{
    [Route("webapi2")]
    public class WebApi2Controller : Controller
    {
        [HttpGet("HelloWorld")]
        public IActionResult HelloWorld()
        {
            return Ok("Hello world");
        }

        [HttpGet("PrintDayOfWeek")]
        public IActionResult PrintDayOfWeek()
        {
            DateTime dateValue = DateTime.Now;              //Extrauppgift: sätt dateValue till new DateTime(2009,01,28)
            string weekDay = dateValue.ToString("dddd",
                              new CultureInfo("sv-SE"));

            DateTime dateValue2 = new DateTime(2009, 01, 28);
            string weekDayTenYearsAgo = dateValue2.ToString("dddd", new CultureInfo("sv-SE"));

            return Ok($"Idag är det {weekDay} - För tio år sedan exakt var det {weekDayTenYearsAgo}");
        }

        [HttpGet("PrintPhraseOfTheDay")]
        public IActionResult PrintPhraseOfTheDay()
        {
            DateTime dateValue = DateTime.Now;
            string weekDay = dateValue.ToString("dddd");

            string phrase = "";

            switch (weekDay)
            {
                case "måndag":
                    phrase = "Det bästa med måndagar är att det är en hel vecka kvar tills det är måndag igen!";
                    break;
                case "tisdag":
                    phrase = "Tisdag, veckan är fortfarande full med möjligheter!";
                    break;
                case "onsdag":
                    phrase = "Lill-lördag!!";
                    break;
                case "torsdag":
                    phrase = "Kaka? På en torsdag?";
                    break;
                case "fredag":
                    phrase = "Dags för fredagsmys!";
                    break;
                case "lördag":
                    phrase = "Melodifestivalen 2019!!";
                    break;
                case "söndag":
                    phrase = "Ta lite tid att umgås med familj och vänner idag";
                    break;
                default:
                    phrase = "Hmm något gick nog fel..";
                    break;
            }

            return Ok(phrase);
        }
    }
}
