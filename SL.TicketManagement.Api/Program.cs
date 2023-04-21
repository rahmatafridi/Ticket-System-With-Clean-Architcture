using SL.TicketManagement.Api;
var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfiureServices().ConfiurePipline();
app.Run();
