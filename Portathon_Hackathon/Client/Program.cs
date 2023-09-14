using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portathon_Hackathon.Client;
using Portathon_Hackathon.Client.Services.Abstract;
using Portathon_Hackathon.Client.Services.Concrete;
using Portathon_Hackathon.Client.Services.Helper;
using Portathon_Hackathon.Client.TokenProcess;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddScoped<IRequestManager, ReqeustManager>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddOptions();
await builder.Build().RunAsync();
