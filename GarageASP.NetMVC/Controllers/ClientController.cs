using GarageASP.NetMVC.Interfaces;
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

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Client client)
        {
            if(!ModelState.IsValid) return View(client);
            _clientRepository.Add(client);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Client client = await _clientRepository.GetClientById(id);
            if(client == null) { return Content( "No client with this ID" ); }
            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Client client)
        {
            if (!ModelState.IsValid) return View(client);
            _clientRepository.Update(client);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            Client client = await _clientRepository.GetClientById(id);
            if (client == null) { return Content("No client with this ID"); }
            return View(client);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _clientRepository.GetClientById(id);
            if (client == null) return Content("No client with this ID");

           _clientRepository.Delete(client);
            return RedirectToAction("Index");
        }
    }
}
