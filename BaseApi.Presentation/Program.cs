var builder = WebApplication.CreateBuilder(args);

//Add For Api:1
builder.Services.AddControllers();//ASP.NET Core MVC (Model-View-Controller) altyapısını uygulamanıza dahil etmek için kullanılır. 

var app = builder.Build();


//Add For Api:2
app.MapControllers(); //ASP.NET Core uygulamasında HTTP isteklerini API kontrollerine yönlendirmek için kullanılan bir yöntemdir

app.Run();
