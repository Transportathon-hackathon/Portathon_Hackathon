using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Portathon_Hackathon.Server.Context;
using Portathon_Hackathon.Server.Extension;
using Portathon_Hackathon.Server.Services.Abstract;
using Portathon_Hackathon.Server.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddPersistenceLayerIdentityExt(builder.Configuration);
builder.Services.AddPersistenceSwaggerExt(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
         c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyBlazor v1"));
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
