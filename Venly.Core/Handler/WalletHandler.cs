using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venly.Model;
using Venly.Model.Requests;

namespace Venly.Handler
{
    public class WalletHandler: VenlyAPIClientBase
    {
        WalletHandler(string accessToken, VenlyEnvironmentConfig cfg) : base(accessToken, cfg) {}

        /// <summary>
        /// Create a new Wallet
        /// POST https://api.arkane.network/api/wallets
        /// </summary>
        /// <see href="https://docs.venly.io/api/api-products/wallet-api/create-wallet">Read more</see>
        /// <returns cref="Wallet">The newly created wallet</returns>
        public async Task<VenlyResponseBase<Wallet>?> CreateWalletAsync(CreateWalletRequest request)
        {
            return await this.PostAsync<Wallet>($"/wallets", JsonConvert.SerializeObject(request));
        }


        /// <summary>
        /// Get all wallets
        /// GET https://api.arkane.network/api/wallets
        /// </summary>
        /// <returns cref="List{Wallet}">A list of Wallets</returns>
        public async Task<VenlyResponseBase<List<Wallet>>?> GetWalletsAsync()
        {
            return await GetAsync<List<Wallet>>($"/wallets");
        }


        /// <summary>
        /// Get a single wallet by common identifier
        /// GET https://api-arkane.network/api/wallets?identifier=<COMMON_IDENTIFIER>
        /// </summary>
        /// <param name="identifier">A common identifier for the wallet, ie 'user_id=ABC123'</param> 
        /// <returns cref="Wallet">A specific Wallet</returns>
        public async Task<VenlyResponseBase<Wallet>?> GetWalletByIdentifierAsync(string identifier)
        {
           return await this.GetAsync<Wallet>($"/wallets?identifier=${identifier}"); 
        }

        /// <summary>
        /// Get a single wallet by Id
        /// GET https://api-arkane.network/api/wallets/wallet_id
        /// </summary>
        /// <returns cref="Wallet">A specific Wallet</returns>
        public async Task<VenlyResponseBase<Wallet>?> GetWalletByIdAsync(string walletId)
        {
            return await this.GetAsync<Wallet>($"/wallets/${walletId}");
        }


        /// <summary>
        /// Get a single wallet by Id
        /// GET https://api-arkane.network/api/wallets/wallet_id/balance
        /// </summary>
        /// <returns cref="Wallet">A specific Wallet</returns>
        public async Task<VenlyResponseBase<Balance>?> GetWalletBalanceAsync(string walletId)
        {
            return await this.GetAsync<Balance>($"/wallets/{walletId}/balance");
        }

        /// <summary>
        /// Retrieve NFTs by Wallet Id
        /// GET https://api.arkane.network/api/wallets/<walletId>/nonfungibles
        /// </summary>
        /// <returns cref="NonFungible">A list of NFTs</returns>
        public async Task<VenlyResponseBase<NonFungible>?> GetNftsByWalletId(string walletId)
        {
            return await this.GetAsync<NonFungible>($"/wallets/{walletId}/balance");
        }

        /// <summary>
        /// Retrieve NFTs by Wallet Address
        /// GET https://api.arkane.network/api/wallets/<SecretType>/<walletAddress>/nonfungibles
        /// </summary>
        /// <returns cref="NonFungible">A list of NFTs</returns>
        public async Task<VenlyResponseBase<NonFungible>?> GetNftsByWalletAddress(string walletAddress)
        {
            return await this.GetAsync<NonFungible>($"/wallets/{walletAddress}/balance");
        }


    }
}
