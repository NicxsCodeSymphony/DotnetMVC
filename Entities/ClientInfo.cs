using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace NICO.Entities;

public partial class ClientInfo
{
    public int Id { get; set; }
    [Required]
    public int? UserType { get; set; }
 [Required]
    public string? FistName { get; set; }
 [Required]
    public string? MiddleName { get; set; }
 [Required]
    public string? LastName { get; set; }
 [Required]
    public string? Address { get; set; }
 [Required]
    public int? ZipCode { get; set; }
 [Required]
    public DateTime? Birthdate { get; set; }
 [Required]
    public int? Age { get; set; }
 [Required]
    public string? NameOfFather { get; set; }
 [Required]
    public string? NameOfMother { get; set; }
 [Required]
    public string? CivilStatus { get; set; }
 [Required]
    public string? Religion { get; set; }
 [Required]
    public string? Occupation { get; set; }
}
