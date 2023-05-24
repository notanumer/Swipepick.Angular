using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swipepick.Angular.DataAccess;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;
using Swipepick.Angular.Web.Infrastructure.DependencyInjection;
using Swipepick.Angular.Web.Infrastructure.Startup;
using Swipepick.Angular.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddSwaggerGen(new SwaggerGenOptionsSetup().Setup);

// Jwt.
var jwtSecret = builder.Configuration["JwtAuth:Key"] ?? throw new ArgumentNullException("JwtAuth:Key");
var jwtIssuer = builder.Configuration["JwtAuth:Issuer"] ?? throw new ArgumentNullException("JwtAuth:Issuer");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(new JwtBearerOptionsSetup(jwtIssuer, jwtSecret).Setup);

// AutoMapper.
AutoMapperModule.Register(builder.Services);

// MediatR.
MediatRModule.Register(builder.Services);

// Database.
var databaseConnectionString = builder.Configuration.GetConnectionString("AppDatabase")
            ?? throw new ArgumentNullException("ConnectionStrings:AppDatabase", "Database connection string is not initialized");
builder.Services.AddDbContext<AppDbContext>(new DbContextOptionsSetup(databaseConnectionString).Setup);
builder.Services.AddAsyncInitializer<DatabaseInitializer>();
builder.Services.AddScoped<IAppDbContext, AppDbContext>();

// Controllers.
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapControllers();
app.Map("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

await app.InitAsync();
await app.RunAsync();
