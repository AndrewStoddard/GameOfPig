// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 02-24-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 02-25-2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewStoddardGameOfPig.Models
{
    /// <summary>
    /// Class GameSession.
    /// </summary>
    public class GameSession
    {
        /// <summary>
        /// The cpu score key
        /// </summary>
        private const string cpuScoreKey = "cpuscore";
        /// <summary>
        /// The player total score key
        /// </summary>
        private const string playerTotalScoreKey = "playertotalscore";
        /// <summary>
        /// The player round score key
        /// </summary>
        private const string playerRoundScoreKey = "playerroundscore";

        /// <summary>
        /// The game in progress key
        /// </summary>
        private const string gameInProgressKey = "gip";

        /// <summary>
        /// The player turn key
        /// </summary>
        private const string playerTurnKey = "playerturn";

        /// <summary>
        /// The die1 value key
        /// </summary>
        private const string die1ValueKey = "die1value";

        /// <summary>
        /// The die2 value key
        /// </summary>
        private const string die2ValueKey = "die2value";

        /// <summary>
        /// The win message key
        /// </summary>
        private const string winMessageKey = "playerturn";



        /// <summary>
        /// Gets or sets the session.
        /// </summary>
        /// <value>The session.</value>
        private ISession session { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GameSession" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public GameSession(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Sets the cpu score.
        /// </summary>
        /// <param name="score">The score.</param>
        public void SetCPUScore(int score) => this.session.SetInt32(cpuScoreKey, score);
        /// <summary>
        /// Gets the get cpu score.
        /// </summary>
        /// <value>The get cpu score.</value>
        public int GetCPUScore => this.session.GetInt32(cpuScoreKey) ?? 0;

        /// <summary>
        /// Sets the player total score.
        /// </summary>
        /// <param name="score">The score.</param>
        public void SetPlayerTotalScore(int score) => this.session.SetInt32(playerTotalScoreKey, score);
        /// <summary>
        /// Gets the get player total score.
        /// </summary>
        /// <value>The get player total score.</value>
        public int GetPlayerTotalScore => this.session.GetInt32(playerTotalScoreKey) ?? 0;

        /// <summary>
        /// Sets the player round score.
        /// </summary>
        /// <param name="score">The score.</param>
        public void SetPlayerRoundScore(int score) => this.session.SetInt32(playerRoundScoreKey, score);
        /// <summary>
        /// Gets the get player round score.
        /// </summary>
        /// <value>The get player round score.</value>
        public int GetPlayerRoundScore => this.session.GetInt32(playerRoundScoreKey) ?? 0;

        /// <summary>
        /// Sets the game in progress.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void SetGameInProgress(bool value) => this.session.SetBoolean(gameInProgressKey, value);
        /// <summary>
        /// Gets a value indicating whether this instance is game in progress.
        /// </summary>
        /// <value><c>true</c> if this instance is game in progress; otherwise, <c>false</c>.</value>
        public bool IsGameInProgress => this.session.GetBoolean(gameInProgressKey);

        /// <summary>
        /// Sets the is player turn.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void SetIsPlayerTurn(bool value) => this.session.SetBoolean(playerTurnKey, value);
        /// <summary>
        /// Gets a value indicating whether [get is player turn].
        /// </summary>
        /// <value><c>true</c> if [get is player turn]; otherwise, <c>false</c>.</value>
        public bool GetIsPlayerTurn => this.session.GetBoolean(playerTurnKey);

        /// <summary>
        /// Sets the die1 value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetDie1Value(int value) => this.session.SetInt32(die1ValueKey, value);
        /// <summary>
        /// Gets the get die1 value.
        /// </summary>
        /// <value>The get die1 value.</value>
        public int GetDie1Value => this.session.GetInt32(die1ValueKey) ?? 1;

        /// <summary>
        /// Sets the die2 value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetDie2Value(int value) => this.session.SetInt32(die2ValueKey, value);
        /// <summary>
        /// Gets the get die2 value.
        /// </summary>
        /// <value>The get die2 value.</value>
        public int GetDie2Value => this.session.GetInt32(die2ValueKey) ?? 1;

        /// <summary>
        /// Sets the win message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SetWinMessage(string message) => this.session.SetString(winMessageKey, message);
        /// <summary>
        /// Gets the get win message.
        /// </summary>
        /// <value>The get win message.</value>
        public string GetWinMessage => this.session.GetString(winMessageKey);

    }
}
