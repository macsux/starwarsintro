using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers();
var app = builder.Build();
app.UseDefaultFiles();
app.UseRouting();
app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build());
app.UseStaticFiles();

app.Run();