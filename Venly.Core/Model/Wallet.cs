using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venly.Model
{

    public class Wallet
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("walletType")]
        public string? WalletType { get; set; }

        [JsonProperty("secretType")]
        public string? SecretType { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("alias")]
        public string? Alias { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }

        [JsonProperty("hasCustomPin")]
        public bool HasCustomPin { get; set; }

        [JsonProperty("identifier")]
        public string? Identifier { get; set; }

        [JsonProperty("balance")]
        public Balance? Balance { get; set; }
    }

    public partial class Balance
    {
        [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("secretType")]
        public string? SecretType { get; set; }

        [JsonProperty("balance")]
        public long BalanceBalance { get; set; }

        [JsonProperty("gasBalance")]
        public long GasBalance { get; set; }

        [JsonProperty("symbol")]
        public string? Symbol { get; set; }

        [JsonProperty("gasSymbol")]
        public string? GasSymbol { get; set; }

        [JsonProperty("rawBalance")]
        public long RawBalance { get; set; }

        [JsonProperty("rawGasBalance")]
        public long RawGasBalance { get; set; }

        [JsonProperty("decimals")]
        public long Decimals { get; set; }
    }
}
