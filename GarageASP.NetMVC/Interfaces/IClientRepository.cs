using GarageASP.NetMVC.Models;

namespace GarageASP.NetMVC.Interfaces
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetAllClient();
        public Task<Client> GetClientById(int id);
    }
}
