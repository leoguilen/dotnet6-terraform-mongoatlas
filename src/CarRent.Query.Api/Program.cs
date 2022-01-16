var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.UseGlobalRoutePrefix("api/v1"));
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerSetup =>
{
    swaggerSetup.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRentQueryApi", Version = "v1" });
    swaggerSetup.EnableAnnotations();
});

builder.Services.AddMongoClient(builder.Configuration);
builder.Services.AddScoped<ICarsCatalogRepository, MongoDbCarsCatalogRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

await app.RunAsync();