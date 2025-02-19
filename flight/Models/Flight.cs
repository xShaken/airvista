using System;
using System.ComponentModel.DataAnnotations;

namespace flight.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        public TimeSpan ArrivalTime { get; set; }

        [Required]
        public string FromLocation { get; set; }

        [Required]
        public string ToLocation { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string Airline { get; set; }
    }
}
