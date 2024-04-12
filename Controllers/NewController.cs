using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NICO.Entities;

namespace NICO.Controllers
{
    public class NewController : Controller
    {

        private readonly EdisanTheLenderMachineContext _context ;


        public NewController(EdisanTheLenderMachineContext context)
        {
           _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.UserTypes.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create(){
            return View(new List<UserType>());
        }

        [HttpPost]
        public IActionResult Create(UserType b){

           if(ModelState.IsValid){
             _context.UserTypes.Add(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
           }
            
            return View(new List<UserType>());
            
        }

        [HttpGet]
        public IActionResult Update(int id){
            var Lending = _context.UserTypes.Where( q => q.Id == id).FirstOrDefault();
            return View(Lending);
        }

        
        [HttpPost]
        public IActionResult Update(UserType b){
             if (ModelState.IsValid)
    {
        var existingClientInfo = _context.UserTypes.FirstOrDefault(q => q.Id == b.Id);
        if (existingClientInfo != null)
        {
            existingClientInfo.Name = b.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
    return View(b); 
        }

        [HttpGet]
        public IActionResult Delete(int id){
            var Lending = _context.UserTypes.Where( q => q.Id == id).FirstOrDefault();
            _context.UserTypes.Remove(Lending);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}