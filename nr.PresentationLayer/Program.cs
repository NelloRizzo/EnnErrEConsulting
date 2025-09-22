using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using nr.BusinessLayer.EF;
using nr.PresentationLayer.Configuration.Automapper;
using nr.PresentationLayer.Configuration.ExceptionHandlers;
using nr.PresentationLayer.Configuration.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options =>
        options.Filters.Add<ModelValidationFilterAttribute>()
    );

builder.Services
    .AddExceptionHandler<GlobalExceptionHandler>()
    .AddProblemDetails()
    .Configure<ApiBehaviorOptions>(cfg => cfg.SuppressModelStateInvalidFilter = true)
    .AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Public")))
    ;

builder.Services.AddOpenApi("v1");

builder.Services
    .AddAuthentication(cfg => {
        cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"]!,
        ValidAudience = builder.Configuration["Jwt:Audience"]!,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    });

// Application services
builder.Services
    .AddCors(cfg => cfg.AddPolicy("cors", cfg => cfg.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()))
    .ConfigureApplicationServices(builder.Configuration)
    .AddSingleton(new MapperConfiguration(cfg => cfg.AddProfile<ModelsMappings>()).CreateMapper())
    ;

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();

    app.UseCors("cors");

    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });

}

app.UseExceptionHandler().UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
