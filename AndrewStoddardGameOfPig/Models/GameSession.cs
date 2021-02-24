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
        private const string playerScoreKey = "playerscore";
        private ISession session { get; set; }
        public GameSession(ISession session)
        {
            this.session = session;
        }

        public void SetCPUScore(int score) => this.session.SetInt32(cpuScoreKey, score);
        public int? GetCPUScore => this.session.GetInt32(cpuScoreKey);

        public void SetPlayerScore(int score) => this.session.SetInt32(playerScoreKey, score);
        public int? GetPlayerScore => this.session.GetInt32(playerScoreKey);
    }
}
