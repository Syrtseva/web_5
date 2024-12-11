using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Lab6.Models;
using Lab6.Services;

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        var clientService = new HttpClientService(httpClient);

        var newPost = new PostData
        {
            Title = "My New Post",
            Body = "This is the body of the post.",
            UserId = 1,
        };

        var getResponse = await clientService.GetAsync("posts");
        Console.WriteLine(
            $"GET Response: {getResponse.Message}, Status Code: {getResponse.StatusCode}"
        );
        foreach (var post in getResponse.Data)
        {
            Console.WriteLine(
                $"ID: {post.Id}, Title: {post.Title}, Body: {post.Body}, UserId: {post.UserId}"
            );
        }

        var postResponse = await clientService.PostAsync("posts", newPost);
        Console.WriteLine(
            $"POST Response: {postResponse.Message}, Status Code: {postResponse.StatusCode}"
        );

        if (postResponse.Data.Count > 0)
        {
            var createdPost = postResponse.Data[0];
            Console.WriteLine($"Created Post ID: {createdPost.Id}, Title: {createdPost.Title}");
            Console.WriteLine(
                $"ID: {createdPost.Id}, Title: {createdPost.Title}, Body: {createdPost.Body}, UserId: {createdPost.UserId}\n"
            );
        }
    }
}
