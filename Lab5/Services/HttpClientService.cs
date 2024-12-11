using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Lab6.Models;

namespace Lab6.Services
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://jsonplaceholder.typicode.com";

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<PostData>> GetAsync(string endpoint)
        {
            try
            {
                var url = $"{_baseUrl}/{endpoint}";
                var response = await _httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var data = JsonSerializer.Deserialize<List<PostData>>(content);
                    return new ApiResponse<PostData>("Success", (int)response.StatusCode, data);
                }
                else
                {
                    return new ApiResponse<PostData>("Error", (int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<PostData>($"Exception: {ex.Message}", 500);
            }
        }

        public async Task<ApiResponse<PostResponse>> PostAsync(string endpoint, PostData postData)
        {
            try
            {
                var url = $"{_baseUrl}/{endpoint}";
                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(postData),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                var response = await _httpClient.PostAsync(url, jsonContent);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var data = JsonSerializer.Deserialize<PostResponse>(content);
                    return new ApiResponse<PostResponse>(
                        "Success",
                        (int)response.StatusCode,
                        new List<PostResponse> { data }
                    );
                }
                else
                {
                    return new ApiResponse<PostResponse>("Error", (int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<PostResponse>($"Exception: {ex.Message}", 500);
            }
        }
    }
}
