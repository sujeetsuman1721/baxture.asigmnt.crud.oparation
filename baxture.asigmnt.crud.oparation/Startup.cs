using Autofac;
using baxture.asigmnt.crud.oparation.Configurations;
using Microsoft.AspNetCore.Builder;
using System.Text.Json;

public class Startup
{

    private readonly IWebHostEnvironment webHostEnvironment;
    public IConfiguration Configuration { get; set; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        this.webHostEnvironment = env;
        this.Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().AddJsonOptions(option =>
        option.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        
        ) ;
        services.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy",
                builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());
        });

        services.AddSwaggerGen(options =>
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "The Baxture crud oparation service", Version = "v1" })
        );

    }

    public static void ConfigureContainer(ContainerBuilder builder)
    {
        var serviceCollection = new ServiceCollection();
        builder.RegisterApplicationServices(serviceCollection)
            .RegiterMapper();


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health");
            endpoints.MapControllers();
        });
        app.UseSwagger(c => c.RouteTemplate = "bacture-swagger/swagger.json");
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = "baxture-swagger";
            c.SwaggerEndpoint("v1/swagger.json", "Comments");
        });

    }
}