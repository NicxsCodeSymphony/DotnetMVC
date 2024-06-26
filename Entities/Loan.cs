﻿using System;
using System.Collections.Generic;

namespace NICO.Entities;

public partial class Loan
{
    public int Id { get; set; }

    public int Borrower { get; set; }

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
