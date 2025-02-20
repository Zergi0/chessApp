using chessApp.ChessServices;
using chessApp.Game;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IGame, Game>();
builder.Services.AddScoped<IChessService, ChessService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
