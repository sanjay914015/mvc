using Microsoft.EntityFrameworkCore;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped < IArticleService, ArticleService > ();
var app = builder.Build();


app.MapGet("/articles", async (IArticleService articleService) => await articleService.GetArticles());

app.MapGet("/articles/{id}", async (int id, IArticleService articleService) => await articleService.GetArticleById(id));

app.MapPost("/articles", async (ArticleRequest articleRequest, IArticleService articleservice) => await articleservice.CreateArticle(articleRequest));

app.MapPut("/articles/{id}", async (int id, ArticleRequest articleRequest, IArticleService articleservice) => await articleservice.UpdateArticle(id, articleRequest));

app.MapDelete("/articles/{id}", async (int id, IArticleService articleservice) => await articleservice.DeleteArticle(id));

app.Run();



//app.MapGet("/sum/{n1}/{n2}", (int? n1, int? n2) => n1 + n2);


//app.MapGet("/", () => MyHandler.Hello);
//app.MapGet("/mult/{n1}&{n2}", (int n1, int n2) => multi.Results(n1,n2));

//public class multi
//{
//    public static int Results(int n1,int n2)
//    {
//        return (n1 * n2);
//    }
//}


//app.Urls.Add("https://localhost:5000");
//app.Urls.Add("https://localhost:4000");


//public class MyHandler
//{
//    public static string Hello { get; set; } = "gfdgfd";
//}