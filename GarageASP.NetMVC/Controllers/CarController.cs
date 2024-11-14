using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageASP.NetMVC.Models;
using GarageASP.NetMVC.Interfaces;
using GarageASP.NetMVC.ViewModels;

namespace GarageASP.NetMVC.Controllers
{
    public class CarController : Controller
    {
        private IGarageManagement _garageManagement;
        public CarController(IGarageManagement garageManagement)
        {
            _garageManagement = garageManagement;
        }

        public async Task<IActionResult> Index() 
        {
            List<Car>? voitures = await _garageManagement.GetAllAsync();
            return View(voitures);
        }

        public async Task<IActionResult> AddCar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(Car voiture)
        {
            if (!ModelState.IsValid) return View(voiture);
            _garageManagement.Add(voiture);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditCar(string id)
        {
            var voiture = await _garageManagement.GetVoitureByIdAsync(id);
            if (voiture == null) return View("Error");
            var voitureVM = new EditCarModel
            {
                Immatriculation= voiture.Immatriculation,
                Modele= voiture.Modele,
                Marque = voiture.Marque,
                Etat= voiture.Etat
            };
            return View(voitureVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditCar(string id, EditCarModel voitureVM)
        {
            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("EditVoiture", voitureVM);
            };

            var voiture = new Car
            {
                Immatriculation= id,
                Modele = voitureVM.Modele,
                Marque = voitureVM.Marque,
                Etat = voitureVM.Etat
            };
            
           _garageManagement.Update(voiture);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DetailCar(string id)
        {
            var voiture = await _garageManagement.GetVoitureByIdAsync(id);
            if (voiture == null) return View("Error");
            return View(voiture);
        }
    }
}
