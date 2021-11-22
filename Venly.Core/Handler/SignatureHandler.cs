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
    public class SignatureHandler: VenlyAPIClientBase
    {
        SignatureHandler(string accessToken, VenlyEnvironmentConfig cfg) : base(accessToken, cfg) { }

        /// <summary>
        /// Sign a message (arbitrary data)
        /// POST https://api.arkane.network/api/signatures
        /// </summary>
        /// <see href="https://docs.venly.io/api/api-products/wallet-api/sign-a-message">Read more</see>
        public async Task<VenlyResponseBase<SignatureResponse>?> SignMessageArbitrary(SignatureRequest request)
        {
            return await this.PostAsync<SignatureResponse>($"/signatures", JsonConvert.SerializeObject(request));
        }


        /// <summary>
        /// Sign an EIP712 message
        /// POST https://api.arkane.network/api/signatures
        /// </summary>
        /// <see href="https://docs.venly.io/api/api-products/wallet-api/sign-a-message">Read more</see>
        public async Task<VenlyResponseBase<SignatureResponse>?> SignMessageEIP712(SignatureRequest request)
        {
            return await this.PostAsync<SignatureResponse>($"/signatures", JsonConvert.SerializeObject(request));
        }


    }
}
