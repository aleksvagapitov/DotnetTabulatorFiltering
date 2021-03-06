﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotnetTabulatorFiltering.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTabulatorFiltering.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITabulatorRepository _repository;

        public HomeController (ITabulatorRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index ()
        {
            return View ();
        }

        [HttpGet]
        public async Task<IActionResult> GetTabulatorData (int page, int size, List<Dictionary<string, string>> filters, List<Dictionary<string, string>> sorters)
        {
            return Ok (await _repository.GetFilteredData (page, size, filters, sorters));
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error ()
        {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}