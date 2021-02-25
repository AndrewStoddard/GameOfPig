// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 02-24-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 02-25-2021
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
        /// <param name="die1">The die1.</param>
        /// <param name="die2">The die2.</param>
        /// <param name="winMessage">The win message.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult Index(int? die1 = null, int? die2 = null, string winMessage = null)
        {
            ViewBag.Die1 = die1;
            ViewBag.Die2 = die2;
            ViewBag.WinMessage = winMessage;
            return View();
        }
        /// <summary>
        /// Starts the game.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult StartGame()
        {
            GameSession session = new GameSession(HttpContext.Session);
            this.resetGame();
            session.SetGameInProgress(true);
            session.SetIsPlayerTurn(random.Next(2) == 1 ? true : false);

            return RedirectToAction("Index", new { ViewBag.Die1, ViewBag.Die2, ViewBag.WinMessage });
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
                session.SetIsPlayerTurn(false);
            return RedirectToAction("Index", new { ViewBag.Die1, ViewBag.Die2, ViewBag.WinMessage });


            }

            session.SetPlayerRoundScore(session.GetPlayerRoundScore + result);
            return RedirectToAction("Index", new { ViewBag.Die1, ViewBag.Die2, ViewBag.WinMessage });


        }
        /// <summary>
        /// Holds the dice.
        /// </summary>
        /// <param name="die1">The die1.</param>
        /// <param name="die2">The die2.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult HoldDice(int die1, int die2)
        {
            GameSession session = new GameSession(HttpContext.Session);
            session.SetPlayerTotalScore(session.GetPlayerTotalScore + session.GetPlayerRoundScore);
            if (session.GetPlayerTotalScore >= 20)
            {
                return RedirectToAction("GameOver");
            }
            session.SetPlayerRoundScore(0);
            session.SetIsPlayerTurn(false);
            ViewBag.Die1 = die1;
            ViewBag.Die2 = die2;


            return RedirectToAction("Index", new { ViewBag.Die1, ViewBag.Die2, ViewBag.WinMessage });
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
            if (session.GetCPUScore >= 20)
            {
                return RedirectToAction("GameOver");
            }
            session.SetIsPlayerTurn(true);

            return RedirectToAction("Index", new { ViewBag.Die1, ViewBag.Die2, ViewBag.WinMessage });

        }

        /// <summary>
        /// Games the over.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult GameOver()
        {
            GameSession session = new GameSession(HttpContext.Session);

            ViewBag.WinMessage = session.GetPlayerTotalScore > session.GetCPUScore ? "Congrats! You win!" : "You Lose!";
            session.SetGameInProgress(false);

            return RedirectToAction("Index", new { ViewBag.Die1, ViewBag.Die2, ViewBag.WinMessage });
        }
        /// <summary>
        /// Resets the game.
        /// </summary>
        private void resetGame()
        {
            GameSession session = new GameSession(HttpContext.Session);
            session.SetCPUScore(0);
            session.SetPlayerRoundScore(0);
            session.SetPlayerTotalScore(0);
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
            ViewBag.Die1 = die1;
            ViewBag.Die2 = die2;
            if (die1 != 1 && die2 != 1)
            {
                result = die1 + die2;
            }
            return result;
        }


    }
}
