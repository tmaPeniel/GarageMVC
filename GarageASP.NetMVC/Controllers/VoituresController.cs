using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageASP.NetMVC.Models;
using GarageASP.NetMVC.Interfaces;

namespace GarageASP.NetMVC.Controllers
{
    public class VoituresController : Controller
    {
        private IGarageManagement _garageManagement;
        public VoituresController(IGarageManagement garageManagement)
        {
            _garageManagement = garageManagement;
        }

        public async Task<IActionResult> Index() 
        {
            List<Voiture> voitures = await _garageManagement.GetAllAsync();
            return View(voitures);
        }

        public async Task<IActionResult> AddVoiture()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVoiture(Voiture voiture)
        {
            if (!ModelState.IsValid) return View(voiture);
            _garageManagement.Add(voiture);
            return RedirectToAction("Index");

        }
    }
}
