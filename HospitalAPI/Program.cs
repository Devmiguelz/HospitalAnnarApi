using HospitalAPI.Application.Interfaces;
using HospitalAPI.Application.Mapper;
using HospitalAPI.Application.Services;
using HospitalAPI.Domain.Interfaces;
using HospitalAPI.Domain.Services;
using HospitalAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var AllOrigin = "AllOriginRequest";

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllOrigin,
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(GlobalMapper));

builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IPatientDomain, PatientDomain>();

builder.Services.AddTransient<IGenericService, GenericService>();
builder.Services.AddTransient<IGenericDomain, GenericDomain>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllOrigin);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
