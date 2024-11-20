using GarageASP.NetMVC.Models;

namespace GarageASP.NetMVC.Interfaces
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetAllClient();
        public Task<Client> GetClientById(int id);

        public bool ClientExists(int id);
        public bool Add(Client client);
        public bool Update(Client client);
        public bool Delete(Client client);
        public bool Save();
    }
}
