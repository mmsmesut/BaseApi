using BaseApi.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Add For Api:1
builder.Services.AddControllers();//ASP.NET Core MVC (Model-View-Controller) altyapýsýný uygulamanýza dahil etmek için kullanýlýr. 


// Bearer token authentication :1 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });


//Bearer token authentication for JWT token servis :2
builder.Services.AddScoped<ITokenService, TokenService>();

//Swagger : 1
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();// Swagger'ýn API'yi incelemesi ve belgeler oluþturmasý için gereklidir.
builder.Services.AddSwaggerGen(); //Swagger UI ve Swagger belgeleri için gereken tüm ayarlamalarý yapýlandýrmanýza olanak tanýr.

var app = builder.Build();

//Swagger : 2
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //Bu kod bloðu, ASP.NET Core uygulamanýzýn Development ortamýnda Swagger'ý etkinleþtirmek için kullanýlýr. 
{
    app.UseSwagger(); // API'lerinizin yaptýðý iþlemleri ve bu iþlemlerin nasýl kullanýlacaðýný açýklayan metadatalarý içerir.
    app.UseSwaggerUI();//Swagger UI, kullanýcýlarýn API belgelerini görsel olarak keþfetmelerine ve test etmelerine olanak tanýr. 
}

app.UseHttpsRedirection();

//Add For Api:2
app.MapControllers(); //ASP.NET Core uygulamasýnda HTTP isteklerini API kontrollerine yönlendirmek için kullanýlan bir yöntemdir


// Bearer token authentication :3
app.UseAuthentication();
app.UseAuthorization();


app.Run();
