using PainelAdmin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PainelAdmin.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PainelAdmin.Entities;
using PainelAdmin.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PainelAdminContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PainelAdminContext") ?? throw new InvalidOperationException("Connection string 'PainelAdminContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

ContextMongodb.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
ContextMongodb.Database = builder.Configuration.GetSection("MongoConnection:Database").Value;
ContextMongodb.IsSSL = Convert.ToBoolean(builder.Configuration.GetSection("MongoConnection:IsSSL").Value);

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, string>(
    ContextMongodb.ConnectionString, ContextMongodb.Database).AddDefaultTokenProviders();

builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<EmailConfig>>().Value);
builder.Services.AddTransient<IEmailSender, EmailService>();

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
app.UseStaticFiles();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
