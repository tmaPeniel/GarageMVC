using GarageASP.NetMVC.Interfaces;
using GarageASP.NetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageASP.NetMVC.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly GarageManagementContext _context;
        public ClientRepository(GarageManagementContext context) 
        {
            _context = context;
        }

        public bool Add(Client client)
        {
            _context.Add(client);
            return Save();
        }

        public bool ClientExists(int id)
        {
            return _context.Clients.Any(c => c.Id == id);  
        }

        public bool Delete(Client client)
        {
            _context.Remove(client);
            return Save();
        }

        public async Task<List<Client>> GetAllClient()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c=>c.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Client client)
        {
            _context.Update(client);
            return Save();
        }
    }
}
