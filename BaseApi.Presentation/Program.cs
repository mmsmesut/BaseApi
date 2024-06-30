var builder = WebApplication.CreateBuilder(args);

//Add For Api:1
builder.Services.AddControllers();//ASP.NET Core MVC (Model-View-Controller) altyapýsýný uygulamanýza dahil etmek için kullanýlýr. 

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


app.Run();
