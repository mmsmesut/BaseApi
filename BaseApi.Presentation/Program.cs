var builder = WebApplication.CreateBuilder(args);

//Add For Api:1
builder.Services.AddControllers();//ASP.NET Core MVC (Model-View-Controller) altyap�s�n� uygulaman�za dahil etmek i�in kullan�l�r. 

//Swagger : 1
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();// Swagger'�n API'yi incelemesi ve belgeler olu�turmas� i�in gereklidir.
builder.Services.AddSwaggerGen(); //Swagger UI ve Swagger belgeleri i�in gereken t�m ayarlamalar� yap�land�rman�za olanak tan�r.

var app = builder.Build();

//Swagger : 2
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //Bu kod blo�u, ASP.NET Core uygulaman�z�n Development ortam�nda Swagger'� etkinle�tirmek i�in kullan�l�r. 
{
    app.UseSwagger(); // API'lerinizin yapt��� i�lemleri ve bu i�lemlerin nas�l kullan�laca��n� a��klayan metadatalar� i�erir.
    app.UseSwaggerUI();//Swagger UI, kullan�c�lar�n API belgelerini g�rsel olarak ke�fetmelerine ve test etmelerine olanak tan�r. 
}

app.UseHttpsRedirection();

//Add For Api:2
app.MapControllers(); //ASP.NET Core uygulamas�nda HTTP isteklerini API kontrollerine y�nlendirmek i�in kullan�lan bir y�ntemdir


app.Run();
