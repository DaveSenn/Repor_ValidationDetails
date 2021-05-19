using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ValidationDetails;

static IHostBuilder CreateHostBuilder( String[] args ) =>
    Host.CreateDefaultBuilder( args )
        .ConfigureWebHostDefaults( webBuilder => webBuilder.UseStartup<Startup>() );

static void Main( String[] args )
{
    CreateHostBuilder( args )
        .Build()
        .Run();
}