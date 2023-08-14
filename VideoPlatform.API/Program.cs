using VideoPlatform.API;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors((options) =>
{
    options.AddPolicy("All", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });    
});
builder.Services.AddSingleton<TrickyStore>();



var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.UseCors("All");
app.Run();