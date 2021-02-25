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
            GameSession session = new GameSession(HttpContext.Session);
            session.SetGameInProgress(true);
            session.SetIsPlayerTurn(random.Next(2) == 1 ? true : false);

            return View("Index");
        }

        /// <summary>
        /// Rolls the dice.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult RollDice()
        {
            GameSession session = new GameSession(HttpContext.Session);
            int result = rollDice();
            if (result == 0)
            {
                session.SetPlayerRoundScore(0);
                return RedirectToAction("HoldDice");

            }

            session.SetPlayerRoundScore(session.GetPlayerRoundScore + result);
            return View("Index");


        }
        /// <summary>
        /// Holds the dice.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult HoldDice()
        {
            GameSession session = new GameSession(HttpContext.Session);
            session.SetPlayerTotalScore(session.GetPlayerTotalScore + session.GetPlayerRoundScore);
            session.SetPlayerRoundScore(0);
            session.SetIsPlayerTurn(false);


            return View("Index");
        }
        /// <summary>
        /// Lets the computer play
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult ComputerPlay()
        {
            GameSession session = new GameSession(HttpContext.Session);
            int result = rollDice();
            session.SetCPUScore(session.GetCPUScore + result);
            session.SetIsPlayerTurn(true);

            return View("Index");

        }



        /// <summary>
        /// Rolls the dice.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int rollDice()
        {
            int result = 0;
            int die1 = random.Next(1, 6);
            int die2 = random.Next(1, 6);
            if (die1 != 1 && die2 != 1)
            {
                result = die1 + die2;
            }
            return result;
        }


    }
}
