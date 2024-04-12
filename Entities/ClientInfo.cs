using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace NICO.Entities;

public partial class ClientInfo
{
    public int Id { get; set; }

    public int? UserType { get; set; }

      [Required(ErrorMessage = "First Name is required")]
    public string FistName { get; set; }

[Required(ErrorMessage = "Middle Name is required")]
    public string? MiddleName { get; set; }
[Required(ErrorMessage = "Last Name is required")]
    public string? LastName { get; set; }
[Required(ErrorMessage = "Address Name is required")]
    public string? Address { get; set; }
[Required(ErrorMessage = "ZipCode Name is required")]
    public int? ZipCode { get; set; }
[Required(ErrorMessage = "Birthdate Name is required")]
    public DateTime? Birthdate { get; set; }
    public int? Age { get; set; }
[Required(ErrorMessage = "Father Name is required")]
    public string? NameOfFather { get; set; }
[Required(ErrorMessage = "Mother Name is required")]
    public string? NameOfMother { get; set; }
[Required(ErrorMessage = "First Name is required")]
    public string? CivilStatus { get; set; }
[Required(ErrorMessage = "Religion Name is required")]
    public string? Religion { get; set; }
[Required(ErrorMessage = "Occupation Name is required")]
    public string? Occupation { get; set; }
}
