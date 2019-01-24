﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        Random random;
        private Repository repository;
        /***
         * Constructor
         */

        public SpinnerController(Repository repo)
        {
            repository = repo;
            random = new Random();
        }

        /***
         * Entry Page Action
         **/

        [HttpGet]
        public IActionResult Index()
        {
            
                return View();
        }

        [HttpPost]
        public IActionResult Index(Player player)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Spin", player);
            else
                return View();
        }

        /***
         * Spin Action
         **/  
        [HttpGet]       
        public IActionResult Spin(Player player)
        {
            // Create a Spin with its data
            Spin spin = new Spin
            {
                Luck = player.Luck,
                A = random.Next(1, 10),
                B = random.Next(1, 10),
                C = random.Next(1, 10)
            };

            spin.IsWinner = (spin.A == spin.Luck || spin.B == spin.Luck || spin.C == spin.Luck);

            // Store some View data
            ViewBag.Display = spin.IsWinner ? "block": "none";
            ViewBag.FirstName = player.FirstName;
            repository.AddSpins(spin);
            return View(spin);
        }

        /***
         * List Action
         */
        [HttpGet]
        public IActionResult LuckList()
        {
            return View();
        }
    }
}

