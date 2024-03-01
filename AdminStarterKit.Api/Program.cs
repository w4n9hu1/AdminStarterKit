var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () =>
{
    return "hello world";
});

app.MapGet("/register", () =>
{
    return "hello world";
});


app.MapGet("/login", () =>
{
    return "hello world";
});

app.MapGet("/user", () =>
{
    return "hello world";
});

app.MapGet("/admin", () =>
{
    return "hello world";
});

app.Run();
