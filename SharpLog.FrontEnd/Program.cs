using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SharpLog.FrontEnd.Extensions;
using System.Threading.Tasks;

namespace SharpLog.FrontEnd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.SetupDI(builder);

            await builder.Build().RunAsync();
        }
    }
}