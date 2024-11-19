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

        public async Task<List<Client>> GetAllClient()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c=>c.Id == id);
        }
    }
}
