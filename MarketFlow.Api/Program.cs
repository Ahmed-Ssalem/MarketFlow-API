using MarketFlow.Core.Interfaces;
using MarketFlow.Core.Interfaces.Reposetories;
using MarketFlow.Core.Interfaces.Services;
using MarketFlow.Presistence.Context;
using MarketFlow.Presistence.Repositories;
using MarketFlow.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Add DbContext

builder.Services.AddDbContext<MarketFlowDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(MarketFlowDbContext).Assembly.FullName)
        )
    );




builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IStoreServices, StoreServices>();

builder.Services.AddTransient<IProductServices, ProductServices>();

builder.Services.AddTransient(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

builder.Services.AddTransient<IStoreRepository, StoreRepository>();

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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