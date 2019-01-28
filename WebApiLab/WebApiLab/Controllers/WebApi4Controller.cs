using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApiLab.Controllers
{
    [Route("webapi4")]
    public class WebApi4Controller : Controller
    {
        //Beräkna hur många chokladbitar alla får.Det finns 25 bitar från början.

        //Om användaren matar in 0 eller lägre så ge statuskoden Bad Request och lämpligt felmeddelande.

        [HttpGet("CalculatePiecesOfChocolate")]
        public IActionResult CalculatePiecesOfChocolate(double number)
        {
            if (number == 0)
            {
                return BadRequest("Kan ej dela på 0!");
            }
            else if (number < 0)
            {
                return BadRequest("Kan ej dela med ett negativt tal!");
            }

            double numberOfChocolatePieces = 25 / number;

            return Ok($"Alla får {numberOfChocolatePieces:.##} bitar var");
        }

        [HttpGet("GetOrder")]
        public IActionResult GetOrder(string order)
        {
            //Användaren matar in en order på formen XX - 9999.Alltså två bokstäver och sedan fyra siffror. T.ex AB-1234 eller SE-9500.

            //Om fel format på ordernumret matas in så ge bad request med lämpligt meddelande.

            //Om de fyra siffrorna är högre än 3000 så ge not found.

            //Annars ge ok med meddelande, t.ex Order RE - 2523 hittades i databasen.

            if(string.IsNullOrWhiteSpace(order))
            {
                return BadRequest("Du måste skriva någonting!");
            }

            order = order.Trim();
            string pattern = @"^[a-zåäö][a-zåäö]-[1-9]\d\d\d$"; //parenteser gör att det blir grupper

            if (!Regex.IsMatch(order, pattern, RegexOptions.IgnoreCase))
            {
                return BadRequest($"{order} är i fel format!");

            }

            int numbersInOrder = int.Parse(order.Remove(0, 3)); //skapa en nummerdel istället

            if(numbersInOrder > 3000)
            {
                return NotFound("Ordern hittades ej");
            }

            return Ok($"Order {order} hittades i databasen");

        }

        [HttpGet("GetUser")]
        public IActionResult GetUser(string userName)
        {
            string imgUrl = "";
            switch (userName.ToLower())
            {
                case "stewie":
                    throw new Exception("DATA ERROR!!");
                case "peter":
                    imgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Operation_Upshot-Knothole_-_Badger_001.jpg/250px-Operation_Upshot-Knothole_-_Badger_001.jpg";
                    break;
                case "louis":
                case "meg":
                case "chris":
                case "brian":
                    imgUrl = "https://media1.tenor.com/images/d8d7b003cc98b44d2a4ca87e27f0c304/tenor.gif?itemid=9499691";
                    break;

                default:
                    imgUrl = "https://www.emojirequest.com/images/ThumbsDownEmoji.jpg";
                    break;
            }

            string html = $"<html><body><img src={imgUrl}></body></html>";

            return Content(html, "text/html");
        }

        [HttpGet("TurnLightOn")]
        public IActionResult TurnLightOn(bool lightIsOn)
        {
            //Visa en gul sida om checkboxen är ifylld och knappen trycks ner. Annars en grå. Lös detta med javascript.

            string html = "";

            if(lightIsOn == true)
            {
             html = $"<html><body style='background-color: yellow'></body></html>";
            }
            else if (lightIsOn == false)
            {
                html = $"<html><body style='background-color: gray'></body></html>";
            }

            return Content(html, "text / html");
        }
    }
}
