using GameSparks.NET.Entities;
using GameSparks.NET.Services.Leaderboards.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaderboard.Events
{
    class LeaderboardDataResponseScoreEvent : GameSparksLeaderboardUserData
    {
        [JsonProperty("SCORE_ATTR")]
        public int Score { get; set; }
    }
}
