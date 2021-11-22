using Newtonsoft.Json;
using Venly.Model.Enums;

namespace Venly.Model.Requests
{

    public class CreateWalletRequest
    {
        [JsonProperty("pincode")]
        public long Pincode { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("identifier")]
        public string? Identifier { get; set; }

        [JsonProperty("secretType")]
        public SecretType SecretType { get; set; } = SecretType.ETHEREUM;

        [JsonProperty("walletType")]
        public WalletType WalletType { get; set; } = WalletType.WHITE_LABEL;
    }
}
