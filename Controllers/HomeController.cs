using EntertainmentProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EntertainmentProject.Controllers
{
    public class HomeController : Controller
    {

        private IEntertainmentRepository _repo;
        public HomeController(IEntertainmentRepository temp)
        {
            _repo = temp;
        }

        //index page view
        public IActionResult Index()
        {
            return View();
        }

        //privacy view
        public IActionResult Privacy()
        {
            var entertainers = _repo.Entertainers; 
            return View(entertainers);
        }

        // GET: Home/Add
        //to add new entertainers to the db
        public IActionResult AddEntertainer()
        {
            return View(new Entertainer());
        }

        // POST: Home/Add
        //save those entertainers in the db
        [HttpPost]
        public async Task<IActionResult> AddEntertainer(Entertainer entertainer)
        {
            if (ModelState.IsValid)
            {
                // Logic to add entertainer to the database
                _repo.AddEntertainerAsync(entertainer); 
                await _repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entertainer);
        }

        //show specific details on each entertainer in the db
        // GET: Home/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var entertainer = await _repo.GetEntertainerByIdAsync(id);
            if (entertainer == null)
            {
                return NotFound();
            }
            return View(entertainer);
        }

        // GET: Home/Edit/5
        //edit each entertainer
        public async Task<IActionResult> Edit(int id)
        {
            var entertainer = await _repo.GetEntertainerByIdAsync(id);
            if (entertainer == null)
            {
                return NotFound();
            }
            return View(entertainer);
        }

        //save the changes to the edits
        // POST: Home/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Entertainer entertainer)
        {
            _repo.UpdateEntertainerAsync(entertainer);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Home/Delete/5
        //delete an entertainer from the db
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entertainer = await _repo.GetEntertainerByIdAsync(id);
            if (entertainer != null)
            {
                _repo.DeleteEntertainerAsync(entertainer);
                await _repo.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
