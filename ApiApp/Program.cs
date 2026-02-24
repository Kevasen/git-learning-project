using System.Net.Http;
using System.Text.Json;

var client = new HttpClient();
client.DefaultRequestHeaders.UserAgent.ParseAdd("ApiApp/1.0"); // GitHub kräver User-Agent

var url = "https://api.github.com/repos/dotnet/runtime";
var json = await client.GetStringAsync(url);

using var doc = JsonDocument.Parse(json);
var fullName = doc.RootElement.GetProperty("full_name").GetString();
var stars = doc.RootElement.GetProperty("stargazers_count").GetInt32();

Console.WriteLine($"{fullName} has {stars} stars ⭐");