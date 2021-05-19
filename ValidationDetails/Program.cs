using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ValidationDetails
{
    public static class Program
    {
        private static IHostBuilder CreateHostBuilder( String[] args ) =>
            Host.CreateDefaultBuilder( args )
                .ConfigureWebHostDefaults( webBuilder => webBuilder.UseStartup<Startup>() );

        public static void Main( String[] args )
        {
            CreateHostBuilder( args )
                .Build()
                .Run();
        }
    }
}