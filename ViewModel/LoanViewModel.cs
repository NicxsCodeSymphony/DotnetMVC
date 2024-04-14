using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NICO.ViewModel;

public partial class LoanViewModel
{

    public int Id { get; set; }
    [Required]
    public int Borrower { get; set; }

    public string BorrowerName { get; set; } = "";
[Required]
    public int LoanPlan { get; set; }
[Required]
    public int PrincipalLoan { get; set; }
[Required]
    public double Interest { get; set; }
[Required]
    public DateTime Date { get; set; }
[Required]
    public double Monthly { get; set; }
[Required]
    public double Total { get; set; }
}
