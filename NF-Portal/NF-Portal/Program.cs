using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NF_Portal.Data;
var builder = WebApplication.CreateBuilder(args);


var serverVersion = new MariaDbServerVersion(new Version(10,4,24));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NfContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("NfContext") ?? throw new InvalidOperationException("Connection string 'NfContext' not found."), serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
    );

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
