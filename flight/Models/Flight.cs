using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flight.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        public string FlightCode { get; set; }

        [Required]
        public int AirlineId { get; set; }
        [ForeignKey("AirlineId")]
        public Airline Airline { get; set; }

        [Required]
        public string AircraftCode { get; set; }

        [Required]
        public int FromAirportId { get; set; }
        [ForeignKey("FromAirportId")]
        public Airport FromAirport { get; set; }

        [Required]
        public int ToAirportId { get; set; }
        [ForeignKey("ToAirportId")]
        public Airport ToAirport { get; set; }

        [Required]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        public DateTime EstimatedArrivalDateTime { get; set; }

        [Required]
        public int BusinessSeatsAvailable { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BusinessClassPrice { get; set; }

        [Required]
        public int EconomySeatsAvailable { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal EconomyClassPrice { get; set; }

        [Required]
        public int FirstClassSeatsAvailable { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FirstClassPrice { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
