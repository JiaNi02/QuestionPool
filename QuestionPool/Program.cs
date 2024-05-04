using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuestionPool.Models;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Builder;
using QuestionPool;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton(builder.Configuration);

builder.Services.AddDbContext<QuestionPoolDatabaseContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("QuestionPooldb")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;

    // Configure user validation rules
    options.User = new UserOptions
    {
        // Add your customization here
        AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+",
        RequireUniqueEmail = true,
    };
})
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<QuestionPoolDatabaseContext>()
        .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(365);
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});
builder.Services.AddScoped<IFileStorageHelper, LocalFileStorageHelper>();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".res"] = "application/octet-stream";
provider.Mappings[".pexe"] = "application/x-pnacl";
provider.Mappings[".nmf"] = "application/octet-stream";
provider.Mappings[".mem"] = "application/octet-stream";
provider.Mappings[".wasm"] = "application/wasm";
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
    ContentTypeProvider = provider
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapRazorPages();



app.Run();
