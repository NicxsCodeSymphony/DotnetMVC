using System;
using System.Collections.Generic;

namespace NICO.Entities;

public partial class Loan
{
    public int Id { get; set; }

    public int Borrower { get; set; }

    public int LoanPlan { get; set; }

    public int PrincipalLoan { get; set; }

    public double Interest { get; set; }

    public DateTime Date { get; set; }

    public double Monthly { get; set; }

    public double Total { get; set; }
}
