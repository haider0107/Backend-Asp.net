using BOL;
using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<SSDBContext>();
builder.Services.AddIdentity<SSUser,IdentityRole>()
                            .AddEntityFrameworkStores<SSDBContext>()
                            .AddDefaultTokenProviders();
builder.Services.AddSwaggerGen();

//builder.Services.ConfigureApplicationCookie(opt =>
//{
//    opt.Events = new CookieAuthenticationEvents()
//    {
//        //Authentication
//        OnRedirectToLogin = redirectContext =>
//        {
//            redirectContext.HttpContext.Response.StatusCode = 403;
//            return Task.CompletedTask;
//        },
//        OnRedirectToAccessDenied = redirectContext =>
//        {
//            redirectContext.HttpContext.Response.StatusCode = 401;
//            return Task.CompletedTask;
//        }
//    };
//});

//Step-1: Create signingKey from Secretkey
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the JWT Security Token Authentication"));

//Step-2:Create Validation Parameters using signingKey
var tokenValidationParameters = new TokenValidationParameters()
{
    IssuerSigningKey = signingKey,
    ValidateIssuer = false,
    ValidateAudience = false,
    ClockSkew = TimeSpan.Zero
};

//Step-3: Set Authentication Type as JwtBearer
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
        //Step-4: Set Validation Parameter created above
        .AddJwtBearer(jwt =>
        {
            jwt.TokenValidationParameters = tokenValidationParameters;
        });

var app = builder.Build();


app.UseCors(x => x.WithOrigins("http://localhost:3000")
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
