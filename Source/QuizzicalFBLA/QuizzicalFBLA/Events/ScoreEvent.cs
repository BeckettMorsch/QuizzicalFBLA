using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaderboard.Events
{
    // Used in conjunction with GameSparks for adjusting player scores
    class ScoreEvent
    {
        [JsonProperty("@class")]
        private string ClassStr { get { return ".LogEventRequest"; } }

        [JsonProperty("eventKey")]
        public string EventKey { get; set; } = "SCORE_EVT";

        [JsonProperty("playerId")]
        public string PlayerId { get; set; }

        [JsonProperty("SCORE_ATTR")]
        public int SCORE_ATTR { get; set; } = 0;

        public ScoreEvent(string playerId, int highScore)
        {
            this.SCORE_ATTR = highScore;
            this.PlayerId = playerId;
        }
    }
}
