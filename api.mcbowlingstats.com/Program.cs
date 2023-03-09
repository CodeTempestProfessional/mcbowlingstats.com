using api.mcbowlingstats.com.V1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    Environment.SetEnvironmentVariable("FIRESTORE_EMULATOR_HOST", "localhost:8080");
}
Endpoints.CheckDatabaseObject();    //warm up database connection
app.RegisterV1Endpoints();

app.Run();
