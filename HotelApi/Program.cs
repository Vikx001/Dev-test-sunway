using HotelApi.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy to allow requests from the React frontend.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS middleware.
app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

List<Hotel> hotels = new List<Hotel>();

try
{
    // Build the file path for the JSON file.
    var hotelDataPath = Path.Combine(app.Environment.ContentRootPath, "Data", "hotels.json");

    // Read the JSON file content.
    var hotelData = File.ReadAllText(hotelDataPath);

    // Deserialize the root object to extract hotel data.
    var root = JsonSerializer.Deserialize<Root>(hotelData, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    });

    // Populate the hotels list from the deserialized data.
    hotels = root?.Hotels ?? new List<Hotel>();
}
catch (Exception ex)
{
    // Log errors for debugging purposes.
    app.Logger.LogError(ex, "Failed to load or parse the hotel data.");
}

// Map GET /api/hotels to retrieve all hotels.
app.MapGet("/api/hotels", () => hotels)
   .WithName("GetHotels")
   .WithOpenApi();

// Map GET /api/hotels/{id} to retrieve a specific hotel by ID.
app.MapGet("/api/hotels/{id}", (int id) =>
{
    var hotel = hotels.FirstOrDefault(h => h.Id == id);
    return hotel is not null ? Results.Ok(hotel) : Results.NotFound(new { Message = "Hotel not found" });
})
.WithName("GetHotelById")
.WithOpenApi();

// Run the application.
app.Run();
