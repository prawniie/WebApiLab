using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApiLab.Models;

namespace WebApiLab.Controllers
{
    [Route("webapi5")]
    public class WebApi5Controller : Controller
    {
        [HttpGet("AddPerson")]
        public IActionResult AddPerson(SimplePerson simplePerson)
        {
            return Ok($"{simplePerson.Name} som är {simplePerson.Age} år lades till i databasen.");
        }

        [HttpGet("AddPersonValidate")]
        public IActionResult AddPersonValidate(SimplePerson simplePerson)
        {

            if (simplePerson.Name == null)
            {
                if (simplePerson.Age == null)
                {
                    return BadRequest("Du måste ange namn och ålder");
                }

                return BadRequest("Du måste ange ett namn!");
            }

            if (simplePerson.Age == null)
                return BadRequest("Du måste ange en ålder");

            string validName = @"^[a-zåäö]{1,20}$";
            //{n,m}Upprepa minst n gånger men allra högst m gånger (m måste vara större än n)

            if (!Regex.IsMatch(simplePerson.Name, validName, RegexOptions.IgnoreCase))
            {
                return BadRequest($"{simplePerson.Name} är i fel format!");
            }

            //TIPS FRÅN OSCAR: Ha en string array där man fyller på med felmeddelanden och skriver ut på slutet med string join 
            // errors.Add("Förnamnet måste ..");
            //if (string.IsNullOrWhiteSpace(simplePerson.Name))
            //{
            //if (simplePerson.Age == null)
            //{
            //    return BadRequest("Du måste ange namn och ålder");
            //}

            //    return BadRequest("Du måste ange ett namn");

            //}

            //if (simplePerson.Name.Length > 20)
            //{
            //    if (simplePerson.Age < 0 || simplePerson.Age > 120)
            //    {
            //        return BadRequest("Ogiltigt namn och ålder");

            //    }
            //    return BadRequest("Namnet får vara max 20 tecken långt");
            //}

            //if (simplePerson.Age < 0 || simplePerson.Age > 120)
            //    return BadRequest("Ogiltig ålder! Giltig ålder är mellan 0 och 120 år");

            return Ok($"{simplePerson.Name} som är {simplePerson.Age} år lades till i databasen.");
        }

        [HttpGet("AddPersonValidateAttribute")]
        public IActionResult AddPersonValidateAttribute(SimplePersonWithAttributes simplePersonWithAttributes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"{simplePersonWithAttributes.Name} som är {simplePersonWithAttributes.Age} år lades till i databasen.");
        }
    }
}
