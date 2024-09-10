using CustomerManager.API.ExceptionHandler;
using CustomerManager.Application;
using CustomerManager.Infrastructure;
using CustomerManager.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();



//builder.Services.AddDbContext<CustomerManagerDbContext>(o => o.UseInMemoryDatabase("CustomerManagerDb"));

builder.Services.AddApplication()
  .AddInfrastructure(builder.Configuration);
builder.Services.AddExceptionHandler <ApiExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
  var dbContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
  dbContext.Database.EnsureCreated();  // Ensure the in-memory database is created
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
