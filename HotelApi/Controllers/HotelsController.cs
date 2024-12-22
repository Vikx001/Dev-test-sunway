using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using HotelApi.Models;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly List<Hotel> _hotels;

        public HotelsController()
        {
            // Initialize the hotels list to prevent null reference issues.
            _hotels = LoadHotelData() ?? new List<Hotel>();
        }

        // Helper method to load hotel data from the JSON file safely.
       private List<Hotel> LoadHotelData()
{
    try
    {
        using (var reader = new StreamReader("Data/hotels.json")) // Updated path to include 'Data'
        {
            string json = reader.ReadToEnd();
            var root = JsonConvert.DeserializeObject<Root>(json);
            return root?.Hotels ?? new List<Hotel>(); // Extract the list of hotels from the root object
        }
    }
    catch (FileNotFoundException e)
    {
        Console.WriteLine("The JSON file was not found: " + e.Message);
    }
    catch (JsonException e)
    {
        Console.WriteLine("Error parsing JSON data: " + e.Message);
    }
    return new List<Hotel>();
}


        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            // Return the list of hotels, which will be empty if data loading failed.
            return _hotels;
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            // Find the hotel by ID using LINQ.
            var hotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                // Return a 404 Not Found if the hotel doesn't exist.
                return NotFound($"Hotel with ID {id} not found.");
            }
            return hotel;
        }
    }
}
