var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// this method registration alll mvc controller and views in built-in inversion of control(IOC) container
//Dependency Injection
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.Run();

//https:localhost:5000/employyes/Details/5
//Above example called routing base on URL, routing pass id to the arguments