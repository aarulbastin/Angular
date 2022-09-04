using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.AspNetCore;
using EmployeeViewAngular;
using AngularWebAPIProject;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.




WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build()
            .Run();



