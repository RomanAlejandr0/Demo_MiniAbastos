using Demo_MiniAbastos.Client;
using Demo_MiniAbastos.Client.Helpers;
using Demo_MiniAbastos.Client.Repositorios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IManager, Manager>();
builder.Services.AddScoped<IMostrarMensajes, MostrarMensajes>();

await builder.Build().RunAsync();
