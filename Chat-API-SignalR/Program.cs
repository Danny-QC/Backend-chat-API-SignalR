


using Chat_API_SignalR.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddHttpContextAccessor();
builder.WebHost.UseUrls("http://*:5000");


var app = builder.Build();


builder.Services.AddDbContext<ChatContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("conection")));
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseAuthorization();

app.Run();
