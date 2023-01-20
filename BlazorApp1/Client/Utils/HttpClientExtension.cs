using BlazorApp1.Shared.CustomExceptions;
using BlazorApp1.Shared.ResponseModels;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Utils
{
    public static class HttpClientExtension
    {
        public async static Task<TResult> PostGetServiceResponseAsync<TResult, TValue>(this HttpClient client, string url, TValue value, bool ThrowSuccessException = false)
        {
            var httpRes = await client.PostAsJsonAsync(url, value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<ServiceResponse<TResult>>();

                return !res.Success && ThrowSuccessException ? throw new ApiException(res.Message) : res.Value;
            }

            throw new HttpException(httpRes.StatusCode.ToString());
        }

        public async static Task<BaseResponse> PostGetBaseResponseAsync<TValue>(this HttpClient client, string url, TValue value, bool ThrowSuccessException = false)
        {
            var httpRes = await client.PostAsJsonAsync(url, value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<BaseResponse>();

                return !res.Success && ThrowSuccessException ? throw new ApiException(res.Message) : res;
            }

            throw new HttpException(httpRes.StatusCode.ToString());
        }

        public async static Task<T> GetServiceResponseAsync<T>(this HttpClient httpClient, string url, bool ThrowSuccessException = false)
        {
            var httpRes = await httpClient.GetFromJsonAsync<ServiceResponse<T>>(url);

            return !httpRes.Success && ThrowSuccessException ? throw new ApiException(httpRes.Message) : httpRes.Value;
        }
    }
}
