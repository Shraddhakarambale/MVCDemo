using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using Newtonsoft.Json;
using System;

namespace MVCDemo.Controllers
{
    public class AssignmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FeverCheck()
        {
            Fever obj = new Fever(); 
            return View(obj);
        }

        [HttpPost]
        public IActionResult FeverCheck(Fever obj)
        {
            if (obj.BTemp > 37.2)
            {
                obj.TestResult = "You have fever.";
            }
            else
            {
                obj.TestResult = "All right! no fever.";
            }
            return View(obj);
        }

        public IActionResult GuessGame()
        {
            GuessNumber obj = new GuessNumber();
            Random rnd = new Random();

            int sNum = rnd.Next(1,501);
            obj.SecretNum = sNum;
            HttpContext.Session.SetInt32("sNumber", sNum);
            return View(obj);
        }

        [HttpPost]
        public IActionResult GuessGame(GuessNumber obj)
        {
            obj.SecretNum = (int)HttpContext.Session.GetInt32("sNumber");

            if (obj.GuessNum > obj.SecretNum)
            {
                obj.Msg = "Your guess is high!";
            }
            else if (obj.GuessNum < obj.SecretNum)
            {
                obj.Msg = "Your guess is low!";
            }
            else 
            {
                obj.Msg = "You guessed it correct!!";
                HttpContext.Session.Clear();
            }
            return View(obj);
        }
    }
}
