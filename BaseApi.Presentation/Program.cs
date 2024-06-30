var builder = WebApplication.CreateBuilder(args);

//Add For Api:1
builder.Services.AddControllers();//ASP.NET Core MVC (Model-View-Controller) altyapýsýný uygulamanýza dahil etmek için kullanýlýr. 

var app = builder.Build();


//Add For Api:2
app.MapControllers(); //ASP.NET Core uygulamasýnda HTTP isteklerini API kontrollerine yönlendirmek için kullanýlan bir yöntemdir

app.Run();
