using flight.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Flight
{
    [Key]
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
    public int BusinessClassSeats { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal BusinessClassPrice { get; set; }

    [Required]
    public int EconomyClassSeats { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal EconomyClassPrice { get; set; }

    [Required]
    public int FirstClassSeats { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal FirstClassPrice { get; set; }
}
