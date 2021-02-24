using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewStoddardGameOfPig.Models
{
    public class GameSession
    {
        private const string cpuScoreKey = "cpuscore";
        private const string playerTotalScoreKey = "playertotalscore";
        private const string playerRoundScoreKey = "playerroundscore";
        private ISession session { get; set; }
        public GameSession(ISession session)
        {
            this.session = session;
        }

        public void SetCPUScore(int score) => this.session.SetInt32(cpuScoreKey, score);
        public int GetCPUScore => this.session.GetInt32(cpuScoreKey) ?? 0;

        public void SetPlayerTotalScore(int score) => this.session.SetInt32(playerTotalScoreKey, score);
        public int GetPlayerTotalScore => this.session.GetInt32(playerTotalScoreKey) ?? 0;

        public void SetPlayerRoundScore(int score) => this.session.SetInt32(playerRoundScoreKey, score);
        public int GetPlayerRoundScore => this.session.GetInt32(playerRoundScoreKey) ?? 0;
    }
}
