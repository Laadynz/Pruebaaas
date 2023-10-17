using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pruebaaas.Client;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-MX");

await builder.Build().RunAsync();
