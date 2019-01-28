using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLab.Controllers
{
    [Route("webapi3")]
    public class WebApi3Controller : Controller
    {

        [HttpGet("GetBreakfastMessage")]
        public IActionResult GetBreakfastMessage(string food)
        {
            string message = "";
            food = food.Trim();

            if (string.IsNullOrWhiteSpace(food))
            {
                message = "Skriv in din frukostmat!";
            }
            else if (food.ToLower() == "mango")
            {
                message = "Mango är gott!";
            }
            else
            {
                message = $"{food} är äckligt!"; //Skaoa metod som tar första tecknet i ett ord och gör om det till stor bokstav och resterande till små bokstäver, se Oscars lösning
            }

            return Ok(message);
        }

        [HttpGet("GetSquaredNumber")]
        public IActionResult GetSquaredNumber(int number)
        {
            return Ok($"{number} * {number} = {number * number}");
        }

        [HttpGet("GetListOfNumbers")]
        public IActionResult GetListOfNumbers(int number1, int number2)
        {
            List<int> listofNumbers = new List<int>();
            for (int i = number1; i <= number2; i++)
            {
                listofNumbers.Add(i);
            }
            return Ok(string.Join(',',listofNumbers));
        }

        [HttpGet("ChangeBackgroundColor")]
        public IActionResult ChangeBackgroundColor(string color)
        {
            string html = $"<html><body style='background-color: {color}'></body></html>";
            return Content(html, "text / html");
            //return Content($"<style> * {{ background-color: {color};}} </style>");
        }

    }
}
