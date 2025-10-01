using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

// add services to the container

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database"));
}).UseLightweightSessions();

var app = builder.Build();

// configure the HTTP request pipeline
app.MapCarter();

app.Run();
