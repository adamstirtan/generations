using Generations.Data;
using Generations.Data.Contracts;
using Generations.Data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<ApplicationDbContext>(
    builder.Configuration.GetConnectionString("DefaultConnection"));
    
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // [FromBody], [FromQuery], [FromRoute] required for controller parameters
        options.SuppressInferBindingSourcesForParameters = true;
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
