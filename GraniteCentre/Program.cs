using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace GraniteCentre
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //    .ConfigureLogging(factory =>
            //    {
            //        factory.AddConsole();
            //        factory.AddDebug();
            //        factory.AddFilter("Console", level => level >= LogLevel.Information);
            //        factory.AddFilter("Debug", level => level >= LogLevel.Information);
            //    })
            //    .UseKestrel(options =>
            //    {
            //        options.Listen(IPAddress.Loopback, 443, listenOptions =>
            //        {
            //            var serverCertificate = LoadCertificate();
            //            listenOptions.UseHttps(serverCertificate); // <- Configures SSL
            //        });
            //    })
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();

            //host.Run();

            var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();

            host.Run();
        }

        //private static X509Certificate2 LoadCertificate()
        //{
        //    var assembly = typeof(Startup).GetTypeInfo().Assembly;
        //    var embeddedFileProvider = new EmbeddedFileProvider(assembly, "GraniteCentre");
        //    var certificateFileInfo = embeddedFileProvider.GetFileInfo("development.pfx");
        //    using (var certificateStream = certificateFileInfo.CreateReadStream())
        //    {
        //        byte[] certificatePayload;
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            certificateStream.CopyTo(memoryStream);
        //            certificatePayload = memoryStream.ToArray();
        //        }

        //        return new X509Certificate2(certificatePayload, "Jb1tx4fh-");
        //    }
        //}
    }
}
