using AgileBoard.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
var apiBase = builder.Configuration.GetValue<string>("ApiBaseUrl") ?? "https://localhost:5069/";

builder.Services.AddHttpClient<UserStoryAPIClient>(client =>
{
    client.BaseAddress = new Uri(apiBase);
});

builder.Services.AddScoped<IUserStoryAPIClient>(sp =>
{
    var inner = sp.GetRequiredService<UserStoryAPIClient>();
    var logger = sp.GetRequiredService<ILogger<LoggingUserStoryAPIClient>>();
    return new LoggingUserStoryAPIClient(inner, logger);
});

builder.Services.AddHttpClient<IUsuarioAPIClient, UsuarioAPIClient>(client =>
{
    client.BaseAddress = new Uri(apiBase);
});

builder.Services.AddHttpClient<IPokeAPIClient, PokeAPIClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5047/");
});

builder.Services.AddHttpClient<IPokeAvatarService, PokeAvatarService>(client =>
{
    client.BaseAddress = new Uri("https://pokeapi.co/");
});

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
    pattern: "{controller=UserStory}/{action=Index}/{id?}");

app.Run();
