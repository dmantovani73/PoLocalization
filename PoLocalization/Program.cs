// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/portable-object-localization

using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Supporto per la localizzazione PO.
builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddPortableObjectLocalization(options =>
    options.ResourcesPath = "Localization"
);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en"),
        new CultureInfo("it")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Per la gestione della localizzazione delle data annotation (es. Required, ...).
builder.Services.AddDataAnnotationsPortableObjectLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseRequestLocalization();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
