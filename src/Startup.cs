using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CoreCodeCamp.Controllers;
using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreCodeCamp
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<CampContext>();
      services.AddScoped<ICampRepository, CampRepository>();

      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      // services.AddApiVersioning(); // this will allow using default versioning, ie. only 1.0
      services.AddApiVersioning(opt =>
      {
          opt.AssumeDefaultVersionWhenUnspecified = true;
          opt.DefaultApiVersion = new ApiVersion(1, 1); // now the version is 1.1
          opt.ReportApiVersions = true; // report api-supported-versions in response header
          //opt.ApiVersionReader = new QueryStringApiVersionReader("ver"); // use api-versioning with query string ver
          //opt.ApiVersionReader = new HeaderApiVersionReader("X-Version");  // use header versioning
          // use multiple versioning method
          //opt.ApiVersionReader = ApiVersionReader.Combine(
          //    opt.ApiVersionReader = new QueryStringApiVersionReader("ver", "version"),
          //    opt.ApiVersionReader = new HeaderApiVersionReader("X-Version")
          //    );
          opt.ApiVersionReader = new UrlSegmentApiVersionReader();  // do versionstring api/v{version:apiVersion} on all controllers with versioning

          ////Versioning by Conventions
          ////an alternative to attributes
          ////you could have one centrallized place for versioning
          ////choose whatever you like

          ////But i couldn't get this compile
          //opt.Conventions.Controller<TalksController>()
          //  .HasApiVersion(new ApiVersion(1, 0))
          //  .HasApiVersion(new ApiVersion(1, 1))
          //  .Action(c => c.Delete(default(string), default(int)))
          //      .MapToApiVersion(1, 1);

      });
      

      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(cfg =>
      {
        cfg.MapControllers();
      });
    }
  }
}
