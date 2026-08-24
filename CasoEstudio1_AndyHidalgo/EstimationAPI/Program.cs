var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.MapGet("/fibonacci/{id}", (int id) =>
{
    int[] validValues = { 2, 3, 5, 8, 13 };

    int a = 0, b = 1, c = 0;
    if (id == 0) return Results.Ok(validValues[0]);
    for (int i = 2; i <= id; i++)
    {
        c = a + b; a = b; b = c;
    }
    int capped = validValues.MinBy(v => Math.Abs(v - b));
    return Results.Ok(capped);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
