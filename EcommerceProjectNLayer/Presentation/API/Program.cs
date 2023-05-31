using System.Net.Mime;
using API;
using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utility;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    //handle validation

    options.InvalidModelStateResponseFactory = context =>
    {
        var list = context.ModelState
                .SelectMany(m => m.Value.Errors)
                .Select(m => m.ErrorMessage)
                .ToList();
        var validates = string.Concat(list);
        var result = new BadRequestObjectResult(list);
        result.Value = new Result<object>(_ValidationMessages:validates, false);
        result.ContentTypes.Add(MediaTypeNames.Application.Json);
        
        return result;
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                      });
});

builder.Services.AddBusinessModules();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

