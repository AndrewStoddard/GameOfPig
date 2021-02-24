using AndrewStoddardGameOfPig.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AndrewStoddardGameOfPig.Controllers
{
    public class HomeController : Controller
    {
        private Random random = new Random();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StartGame()
        {
            return View("Index");
        }

        public IActionResult RollDice()
        {
            var session = new GameSession(HttpContext.Session);
            int die1 = random.Next(1, 6);
            int die2 = random.Next(1, 6);
            if (die1 == 1 || die2 == 1)
            {
                session.SetPlayerRoundScore(0);

                return View("Index");
            }

            session.SetPlayerRoundScore(session.GetPlayerRoundScore + die1 + die2);
            return View("Index");


        }
        public IActionResult HoldDice()
        {
            var session = new GameSession(HttpContext.Session);
            session.SetPlayerTotalScore(session.GetPlayerTotalScore + session.GetPlayerRoundScore);
            session.SetPlayerRoundScore(0);
            return View("Index");
        }


       
    }
}
