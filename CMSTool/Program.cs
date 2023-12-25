using Business.Services;
using CMS.BusinessLayer.Services;
using Microsoft.OpenApi.Models;
using VueCliMiddleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CMSDbContext>(options =>
{
    // Correct the casing of 'UseSqlServer' and add 'using' statement for 'Configuration'
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cmstool"));
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IGetAvaliabeNews,GetAvaliabeNews>();
builder.Services.AddSingleton<IAvaliableonCMS, AvaliableonCMS>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseHttpsRedirection();
app.UseHttpsRedirection();
app.UseStaticFiles(); // Serve static files like HTML, CSS, and JS

app.UseRouting();

// This configuration serves the Vue.js app from the wwwroot folder.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

    // This catch-all route sends all other requests to the Vue.js app
    // Adjust the path as needed based on your project structure
});

app.MapWhen(
    context => !context.Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase),
    spa =>
    {
        spa.UseSpa(spa =>
        {
            spa.Options.SourcePath = "clientapp"; // Update with your Vue.js app source path

            if (app.Environment.IsDevelopment())
            {
                spa.UseVueCli(npmScript: "serve", port: 8080); // Update with your Vue.js dev server port
            }
        });
    });

app.Run();
