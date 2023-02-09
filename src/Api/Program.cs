using System.Reflection;
using System.Text;
using Api.Mediator;
using Api.Utils;
using Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Validators.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PersonalSoft Insurance Api Web Service",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Daniel Londoño Ospina",
            Email = "daniel_londono82122@elpoli.edu.co"
        }
    });
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Bearer token:",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        { jwtSecurityScheme, Array.Empty<string>() }
                    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

Console.WriteLine("Adding Authentication");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

Console.WriteLine("Adding DB");
var dbConnectionString = DataUtils.GetDbConnectionString(builder.Configuration, builder.Environment.ContentRootPath);
builder.Services.AddDbContext<InsuranceContext>(options =>
                    options.UseSqlServer(dbConnectionString,
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                        sqlOptions.MigrationsAssembly("Api");
                    }));


Console.WriteLine("Adding MediatR");
builder.Services.AddMediatRConf();

Console.WriteLine("Adding AutoMapper");
builder.Services.AddAutoMapper(Assembly.Load("Services"));


Console.WriteLine("Adding DI");
builder.Services.AddScoped<IInsuranceContext, InsuranceContext>();
builder.Services.AddScoped<ICommonValidators, CommonValidators>();

builder.Services.AddValidatorsFromAssembly(typeof(CommonValidators).Assembly);

IdentityModelEventSource.ShowPII = true;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonalSoft Insurance Api Web Service V1");
        c.RoutePrefix = string.Empty;
        c.DisplayOperationId();
        c.DisplayRequestDuration();
        c.EnableDeepLinking();
    });
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.EnsureMigrationOfContext<InsuranceContext>();

app.Run();
