using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLab.Controllers
{
    [Route("webapi0")]
    public class WebApi0Controller : Controller
    {
        [Route("kalle")]
        public string Kalle()
        {
            return "Hej från servern!";
        }

        [Route("kalle2")]
        public string Kalle2()
        {
            return "Klockan är " + DateTime.Now;
        }

        [Route("kalle3")]
        public int Kalle3()
        {
            int i = 10 + 32;
            return i;
        }

        [Route("kalle4"), HttpGet] //Kan användas för att se till att man bara blir insläptt om man vill göra post
        [HttpGet("kalle4")] //Samma sak som det ovan
        public IActionResult Kalle4()
        {
            //return BadRequest(); //tex om användaren matar in epostadress som inte finns
            //return NotFound();
            return Ok("Klockan är " + DateTime.Now); //Ok betyder att allt gick bra, i Ok kan man skicka in typ vad som helst
        }

    }
}
