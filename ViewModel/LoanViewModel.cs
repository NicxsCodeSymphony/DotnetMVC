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

    public int Borrower { get; set; }
    public string? BorrowerName { get; set; } = "";

    public int? Amount { get; set; } 

    public int? Term { get; set; }

    public string? Payment { get; set; } = null!;

    public double? AmountPaid { get; set; }

    public double InterestAmount { get; set; }

    public double? Total { get; set; }

    public double? Interest { get; set; }

    public double Deduction { get; set; }

    public double? ReceivableAmount { get; set; }

    public string? Status { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? DateCreated { get; set; }
}
