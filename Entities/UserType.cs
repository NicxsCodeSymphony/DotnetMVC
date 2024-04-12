using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace NICO.Entities;

public partial class UserType
{
    public int Id { get; set; }
 [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
}
