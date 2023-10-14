using CanoPOS.Client.Repositories;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pruebaaas.Client;
using Pruebaaas.Client.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<ProveedorAuthenticationJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAuthenticationJWT>(proveedor =>
    proveedor.GetRequiredService<ProveedorAuthenticationJWT>());

builder.Services.AddScoped<ILoginService, ProveedorAuthenticationJWT>(proveedor =>
    proveedor.GetRequiredService<ProveedorAuthenticationJWT>());


await builder.Build().RunAsync();
