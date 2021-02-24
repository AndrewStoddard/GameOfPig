// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 02-24-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 02-24-2021
// ***********************************************************************
using AndrewStoddardGameOfPig.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AndrewStoddardGameOfPig.Controllers
{
    /// <summary>
    /// Class HomeController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// The random
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Starts the game.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult StartGame()
        {
            return View("Index");
        }

        /// <summary>
        /// Rolls the dice.
        /// </summary>
        /// <returns>IActionResult.</returns>
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
        /// <summary>
        /// Holds the dice.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult HoldDice()
        {
            var session = new GameSession(HttpContext.Session);
            session.SetPlayerTotalScore(session.GetPlayerTotalScore + session.GetPlayerRoundScore);
            session.SetPlayerRoundScore(0);
            return View("Index");
        }


       
    }
}
