var builder = WebApplication.CreateBuilder(args);

//Add For Api:1
builder.Services.AddControllers();//ASP.NET Core MVC (Model-View-Controller) altyap�s�n� uygulaman�za dahil etmek i�in kullan�l�r. 

var app = builder.Build();


//Add For Api:2
app.MapControllers(); //ASP.NET Core uygulamas�nda HTTP isteklerini API kontrollerine y�nlendirmek i�in kullan�lan bir y�ntemdir

app.Run();
