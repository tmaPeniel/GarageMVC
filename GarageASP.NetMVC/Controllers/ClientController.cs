﻿using GarageASP.NetMVC.Interfaces;
using GarageASP.NetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GarageASP.NetMVC.Controllers
{
    public class ClientController : Controller
    {
        private IGarageManagement _garageManagement;
        private IClientRepository _clientRepository;

        public ClientController(IGarageManagement garageManagement, IClientRepository clientRepository)
        {
            _garageManagement = garageManagement;
            _clientRepository = clientRepository;

        }
        public async Task<IActionResult> Index()
        {
            List<Client> clients = await _clientRepository.GetAllClient();
            return View(clients);
        }
    }
}
