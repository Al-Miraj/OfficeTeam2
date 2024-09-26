
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<ILoginService, LoginService>(); //addsingleton


var app = builder.Build();

new Handler(app);


app.Run();




public class Handler
{
    public Handler(WebApplication app)
    {
        app.Urls.Add("http://localhost:5000/");

        app.MapGet("/", () => "This is without anything");
        app.MapControllers();
        app.Run();

    }
}




// using System.Text.Json;

// PlaceholderDB placeholderDB = new PlaceholderDB();
// // placeholderDB.Seed();

// string jsonContent = File.ReadAllText("test.json");

// // Deserialize the JSON content into a list of Account objects
// List<Account> accounts = JsonSerializer.Deserialize<List<Account>>(jsonContent)!;

// System.Console.WriteLine(accounts[0]);
// System.Console.WriteLine(accounts[1]);
// System.Console.WriteLine(accounts[2]);
public record Account(string Username, string Password);

