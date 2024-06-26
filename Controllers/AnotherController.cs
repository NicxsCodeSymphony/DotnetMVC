using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NICO.Entities;
using NICO.ViewModel;

namespace NICO.Controllers
{
    public class AnotherController : Controller
    {
        private readonly EdisanTheLenderMachineContext _context;

        public AnotherController(EdisanTheLenderMachineContext context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var client = (
                from clientInfo in _context.ClientInfos
                join usertype in _context.UserTypes
                on clientInfo.UserType equals usertype.Id

                select new ClientInfoViewModel
                {
                    Id = clientInfo.Id,
                    UserType = clientInfo.UserType,
                    UserTypeName = usertype.Name,
                    FistName = clientInfo.FistName,
                    MiddleName = clientInfo.MiddleName,
                    LastName = clientInfo.LastName,
                    Address = clientInfo.Address,
                    ZipCode = clientInfo.ZipCode,
                    Birthdate = clientInfo.Birthdate,
                    Age = clientInfo.Age,
                    NameOfFather = clientInfo.NameOfFather,
                    NameOfMother = clientInfo.NameOfMother,
                    CivilStatus = clientInfo.CivilStatus,
                    Religion = clientInfo.Religion,
                    Occupation = clientInfo.Occupation,
                }
            ).AsAsyncEnumerable();


            if (client != null)
                return View(client);
            else
                return Problem("walay clients");

            //   return _context.ClientInfos != null ? 
            //               View(await _context.ClientInfos.ToListAsync()) :
            //               Problem("Entity set 'EdisanTheLenderMachineContext.ClientInfos'  is null.");
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientInfos == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

        public IActionResult AnotherCreate()
        {
            ViewBag.UserTypes = _context.UserTypes.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AnotherCreate(ClientInfo clientInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientInfo);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || _context.ClientInfos == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfos.Where(x => x.Id == id)
                                            .Select(x => new ClientInfoViewModel
                                            {
                                                Id = x.Id,
                                                UserType = x.UserType,
                                                FistName = x.FistName,
                                                MiddleName = x.MiddleName,
                                                LastName = x.LastName,
                                                Address = x.Address,
                                                ZipCode = x.ZipCode,
                                                Birthdate = x.Birthdate,
                                                Age = x.Age,
                                                NameOfFather = x.NameOfFather,
                                                NameOfMother = x.NameOfMother,
                                                CivilStatus = x.CivilStatus,
                                                Religion = x.Religion,
                                                Occupation = x.Occupation,
                                            })
                                            .FirstOrDefaultAsync();
            if (clientInfo == null)
            {
                return NotFound();
            }
            ViewBag.UserTypes = _context.UserTypes.ToList();
            return View(clientInfo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Id,UserType,FistName,MiddleName,LastName,Address,ZipCode,Birthdate,Age,NameOfFather,NameOfMother,CivilStatus,Religion,Occupation")] ClientInfo clientInfo)
        {
            if (id != clientInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientInfoExists(clientInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clientInfo);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Lending = _context.ClientInfos.Where(q => q.Id == id).FirstOrDefault();
            _context.ClientInfos.Remove(Lending);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientInfos == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientInfos == null)
            {
                return Problem("Entity set 'EdisanTheLenderMachineContext.ClientInfos'  is null.");
            }
            var clientInfo = await _context.ClientInfos.FindAsync(id);
            if (clientInfo != null)
            {
                _context.ClientInfos.Remove(clientInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientInfoExists(int id)
        {
            return (_context.ClientInfos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

public async Task<IActionResult> Loan(int id)
{
    var borrower = await _context.ClientInfos.Where(c => c.Id == id)
                        .Select(c => c.FistName + " " + c.LastName)
                        .FirstOrDefaultAsync();

    var loans = await (
        from loan in _context.Loans
        where loan.Borrower == id
        select new LoanViewModel
        {
            Id = loan.Id,
            Borrower = loan.Borrower,
            BorrowerName = borrower,
            Amount = loan.Amount,
            Term = loan.Term,
            Payment = loan.Payment,
            AmountPaid = loan.AmountPaid,
            InterestAmount = loan.InterestAmount,
            Total = loan.Total,
            Status = loan.Status,
            Interest = loan.Interest,
            Deduction = loan.Deduction,
            ReceivableAmount = loan.ReceivableAmount,
            DueDate = loan.DueDate,
            DateCreated = loan.DateCreated
        }
    ).ToListAsync();

    if (loans.Count == 0)
    {
        ViewBag.Message = "No loan yet";
    }

    ViewBag.BorrowerName = borrower;
    ViewBag.BorrowerId = id; // Pass the borrower ID to the view
    return View(loans);
}




       public IActionResult AddLoan(int id)
{
    var loanViewModel = new LoanViewModel { Borrower = id };
    return View(loanViewModel);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> AddLoan(LoanViewModel loan)
{
        // Map LoanViewModel to Loan entity
        var newLoan = new Loan
        {
           Borrower = loan.Borrower,
           Amount = loan.Amount,
           Term = loan.Term,
           Payment = loan.Payment,
           AmountPaid = loan.AmountPaid,
           Total = loan.Total,
           Interest = loan.Interest,
           Deduction = loan.Deduction,
           ReceivableAmount = loan.ReceivableAmount,
           Status = "Processed",
           DueDate = loan.DueDate,
           DateCreated = DateTime.Now
        };

        // Add new loan to the context
        _context.Add(newLoan);
        await _context.SaveChangesAsync();

         return RedirectToAction(nameof(Loan), new { id = loan.Borrower });

    
    // If ModelState is not valid, return the view with the same LoanViewModel
    return View(loan);
}



[HttpDelete]
public async Task<IActionResult> DeleteLoan(int id)
{
    var loan = await _context.Loans.FindAsync(id);
    if (loan == null)
    {
        return NotFound();
    }

    _context.Loans.Remove(loan);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Loan), new { id = loan.Borrower });
}




    }
}