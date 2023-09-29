using System.Reflection;
using ReadingIsGood.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using ReadingIsGood.CQRS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReadingIsGoodContext>(optionsAction: optionsBuilder =>
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        optionsAction =>
        {
            optionsAction.MigrationsAssembly(typeof(ReadingIsGoodContext).GetTypeInfo().Assembly.GetName()
                .Name);
        }));

var assembly = Assembly.Load(builder.Configuration["MigrationsAssembly"]);
builder.Services.AddScoped(mm =>
    new MigrationManager(builder.Configuration.GetConnectionString("DefaultConnection"), assembly));

builder.Services.AddInfrastructure();
builder.Services.AddCqrsHandlers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    ApplyMigrations(app);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ApplyMigrations(IApplicationBuilder app)
{
    using var serviceProviderScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
    var migrationManager = serviceProviderScope.ServiceProvider.GetRequiredService<MigrationManager>();
    migrationManager.MigrateToLatest();
}