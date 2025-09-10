var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// configure the HTTP request pipeline
app.MapCarter();

app.Run();
