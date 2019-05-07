using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaderboard.Events
{
    class AddPointsEvent
    {
        [JsonProperty("@class")]
        private string ClassStr { get { return ".LogEventRequest"; } }

        [JsonProperty("eventKey")]
        public string EventKey { get; set; } = "AddPoints";

        [JsonProperty("playerId")]
        public string PlayerId { get; set; }

        [JsonProperty("currencyRef")]
        public int CurrencyRef { get; set; } = 0;

        [JsonProperty("amount")]
        public int Amount { get; set; } = 0;

        public AddPointsEvent(string playerId, int currencyRef, int amount)
        {
            this.PlayerId = playerId;
            this.CurrencyRef = currencyRef;
            this.Amount = amount;
        }
    }
}
