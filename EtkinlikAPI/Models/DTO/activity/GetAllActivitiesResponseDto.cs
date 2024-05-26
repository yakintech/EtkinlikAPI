﻿namespace EtkinlikAPI.Models.DTO
{
    public class GetAllActivitiesResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string CategoryName { get; set; }

        //latitudes and longitudes
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public List<string> Images { get; set; }
    }
}
