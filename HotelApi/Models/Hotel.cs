namespace HotelApi.Models
{
    public class Root
    {
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
    }

    public class Hotel
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty; 
        public string Location { get; set; } = string.Empty; 
        public double Rating { get; set; } 
        public string ImageUrl { get; set; } = string.Empty; 
        public string[] DatesOfTravel { get; set; } = Array.Empty<string>(); 
        public string BoardBasis { get; set; } = string.Empty; 
        public Room[] Rooms { get; set; } = Array.Empty<Room>(); 
    }

    public class Room
    {
        public string RoomType { get; set; } = string.Empty; 
        public int Amount { get; set; } 
    }
}
