﻿using System;
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
    public class VoituresController : Controller
    {
        private IGarageManagement _garageManagement;
        public VoituresController(IGarageManagement garageManagement)
        {
            _garageManagement = garageManagement;
        }

        public async Task<IActionResult> Index() 
        {
            List<Voiture>? voitures = await _garageManagement.GetAllAsync();
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

        public async Task<IActionResult> EditVoiture(string id)
        {
            var voiture = await _garageManagement.GetVoitureByIdAsync(id);
            if (voiture == null) return View("Error");
            var voitureVM = new EditVoitureModel
            {
                Immatriculation= voiture.Immatriculation,
                Modele= voiture.Modele,
                Marque = voiture.Marque,
                Etat= voiture.Etat
            };
            return View(voitureVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditVoiture(string id, EditVoitureModel voitureVM)
        {
            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("EditVoiture", voitureVM);
            };

            var voiture = new Voiture
            {
                Immatriculation= id,
                Modele = voitureVM.Modele,
                Marque = voitureVM.Marque,
                Etat = voitureVM.Etat
            };
            
           _garageManagement.Update(voiture);
            return RedirectToAction("Index");
        }
    }
}
