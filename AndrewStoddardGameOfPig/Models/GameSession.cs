// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 02-24-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 02-24-2021
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

        private const string playerTurnKey = "playerturn";

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

        public void SetIsPlayerTurn(bool value) => this.session.SetBoolean(playerTurnKey, value);
        public bool GetIsPlayerTurn => this.session.GetBoolean(playerTurnKey);
    }
}
