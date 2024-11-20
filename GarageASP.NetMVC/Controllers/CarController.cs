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
using System.Runtime.ConstrainedExecution;
using GarageASP.NetMVC.Repository;

namespace GarageASP.NetMVC.Controllers
{
    public class CarController : Controller
    {
        private IGarageManagement _garageManagement;
        private IClientRepository _clientRepository;
     
        public CarController(IGarageManagement garageManagement, IClientRepository clientRepository)
        {
            _garageManagement = garageManagement;
            _clientRepository = clientRepository;
      
        }
        


        //Index
        public async Task<IActionResult> Index() 
        {
            List<Car>? voitures = await _garageManagement.GetAllAsync();
            return View(voitures);
        }



        //Add Method
        public async Task<IActionResult> AddCar()
        {
            ViewBag.Client= await _clientRepository.GetAllClient();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(Car voiture)
        {
            if (_garageManagement.CarExists(voiture.Immatriculation))
            {
                ModelState.AddModelError("Immatriculation", "Cette immatriculation existe déjà.");
                return View(voiture);
            }
            if (!ModelState.IsValid) return View(voiture);
            
            _garageManagement.Add(voiture);
            return RedirectToAction("Index");
        }



        //Update method
        public async Task<IActionResult> EditCar(string id)
        {
            var voiture = await _garageManagement.GetVoitureByIdAsync(id);
           
            ViewBag.Client= await _clientRepository.GetAllClient(); 
            if (voiture == null) return View("Error");
            var voitureVM = new EditCarModel
            {
                Immatriculation= voiture.Immatriculation,
                Modele= voiture.Modele,
                Marque = voiture.Marque,
                Etat= voiture.Etat,
                ClientID= voiture.Client.Id
                
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
                Etat = voitureVM.Etat,
                ClientID= voitureVM.ClientID
            };
            
           _garageManagement.Update(voiture);
            return RedirectToAction("Index");
        }



        //Read Method
        public async Task<IActionResult> DetailCar(string id)
        {
            var voiture = await _garageManagement.GetVoitureByIdAsync(id);
            if (voiture == null) return View("Error");
            return View(voiture);
        }



        //Delete Methode
        public async Task<IActionResult> DeleteCar(string id)
        {
            var voiture = await _garageManagement.GetVoitureByIdAsync(id);
            if (voiture == null) return View("Error");
            return View(voiture);
        }

        [HttpPost, ActionName("DeleteCar")]
        public async Task<IActionResult> Delete(string id)
        {
            var voiture = await _garageManagement.GetVoitureByIdAsync(id);
            if (voiture == null) return View("Error");

            _garageManagement.Delete(voiture);
            return RedirectToAction("Index");
        }
    }
}
