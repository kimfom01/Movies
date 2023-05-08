using Microsoft.EntityFrameworkCore;
using Movies.MovieApi;
using Movies.Repositories;
using Movies.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MoviesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesDb"));
});
builder.Services.AddDefaultIdentity<MoviesUser>(options =>
    options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MoviesContext>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IMovieApiService, MovieApiService>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
