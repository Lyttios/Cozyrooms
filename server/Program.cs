using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().AllowAnyOrigin()
));
var app = builder.Build();
app.UseCors();
app.MapGet("/", () => "CozyRooms server running");
app.MapHub<GameHub>("/hubs/game");
app.Run();

public class GameHub : Microsoft.AspNetCore.SignalR.Hub
{
    public async Task JoinRoom(string roomId) {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        // send room state, etc.
    }
}
