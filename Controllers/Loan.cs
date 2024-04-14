using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NICO.Entities;
using NICO.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace NICO.Controllers
{
    public class LoanController : Controller
    {

        private readonly EdisanTheLenderMachineContext _context ;


        public LoanController(EdisanTheLenderMachineContext context)
        {
           _context = context;
        }

        // public IActionResult Index()
        // {
        //     var result = _context.UserTypes.ToList();
        //     return View(result);
        // }

        public async Task<IActionResult> Index()
        {
            var loan = (
                from loans in _context.Loans
                join clientInfo in _context.ClientInfos
                on loans.Borrower equals clientInfo.Id


                select new LoanViewModel
                {
                    Id = loans.Id,
                    Borrower = loans.Borrower,
                    BorrowerName = clientInfo.FistName,
                    LoanPlan = loans.LoanPlan,
                    PrincipalLoan = loans.PrincipalLoan,
                    Interest = loans.Interest,
                    Date = loans.Date,
                    Monthly = loans.Monthly,
                    Total = loans.Total
                }
            ).AsAsyncEnumerable();


            if (loan != null)
                return View(loan);
            else
                return Problem("walay clients");

            //   return _context.ClientInfos != null ? 
            //               View(await _context.ClientInfos.ToListAsync()) :
            //               Problem("Entity set 'EdisanTheLenderMachineContext.ClientInfos'  is null.");
        }

       

    }
}