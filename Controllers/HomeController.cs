using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        //constructor
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;


        }

        // index router
        public IActionResult Index(string teamType)
        {
            if (teamType == null)
            {
                ViewBag.TeamName = "Home";
            }
            else
            {
                ViewBag.TeamName = teamType;
            }

            var blah = _repo.Bowlers
                .Where(b => b.Team.TeamName == teamType || teamType == null)
                .Include(x => x.Team)
                .ToList();
            return View(blah);
        }


        //Route to Add form/function
        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {

            _repo.CreateBowler(b);
            return RedirectToAction("Index");
        }

        //Route to Delete form/function
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowlercheck = _repo.Bowlers.Single(x => x.BowlerID == id); 
            return View(bowlercheck);

        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {

            _repo.DeleteBowler(b);
            return RedirectToAction("Index");
        }

        //Route to Edit form/function
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bowlercheck = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View(bowlercheck);

        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {

            _repo.EditBowler(b);
            return RedirectToAction("Index");
        }


    }
}
