using passfrontend.Components;
using passfrontend.Services;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);
//https://www.freecodecamp.org/news/use-local-storage-in-blazor-apps/
builder.Services.AddBlazoredLocalStorage();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<UsersApiServices>();
builder.Services.AddScoped<UserStateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
