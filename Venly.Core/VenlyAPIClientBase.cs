using Newtonsoft.Json;
using Venly.Model;

namespace Venly
{
    public class VenlyAPIClientBase : HttpClient
    {
        public VenlyAPIClientBase(string accessToken, VenlyEnvironmentConfig config)
        {
            this.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            this.BaseAddress = new Uri("");
        }


        public async Task<VenlyResponseBase<T>?> GetAsync<T>(string url)
        {
            try
            {
                var getResponse = await this.GetAsync(url);
                if (getResponse.IsSuccessStatusCode)
                {
                    var data = new VenlyResponseBase<T>();
                    var content = await getResponse.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<VenlyResponseBase<T>>(content);

                    if (data != null) return data;
                    if (data == null) return new VenlyResponseBase<T> { Success = false, Exception = new Exception(content) };
                } else {
                    var content = await getResponse.Content.ReadAsStringAsync();
                    return new VenlyResponseBase<T> { Success = false, Exception = new Exception(content) };
                }
                return null;
            }
            catch (Exception ex)
            {
                return new VenlyResponseBase<T>()
                {
                    Success = false,
                    Exception = ex
                };
            }
        }

        public async Task<VenlyResponseBase<T>?> PostAsync<T>(string url, string requestPayload)
        {
            try
            {
                var getResponse = await this.PostAsync(url, new StringContent(requestPayload));
                if (getResponse.IsSuccessStatusCode)
                {
                    var data = new VenlyResponseBase<T>();
                    var content = await getResponse.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<VenlyResponseBase<T>>(content);

                    if (data != null) return data;
                    if (data == null) return new VenlyResponseBase<T> { Success = false, Exception = new Exception(content) };
                }
                else
                {
                    var content = await getResponse.Content.ReadAsStringAsync();
                    return new VenlyResponseBase<T> { Success = false, Exception = new Exception(content) };
                }
                return null;
            }
            catch (Exception ex)
            {
                return new VenlyResponseBase<T>()
                {
                    Success = false,
                    Exception = ex
                };
            }
        }



    }
}