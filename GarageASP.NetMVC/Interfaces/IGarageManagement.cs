using GarageASP.NetMVC.Models;

namespace GarageASP.NetMVC.Interfaces
{
    public interface IGarageManagement
    {
        public Task<List<Voiture>> GetAllAsync();
        public Task<Voiture> GetVoitureByIdAsync(string id);

        public Task<List<Voiture>> GetVoitureByMarque(string marque);
        public Task<List<Voiture>> GetVoituresByModel(string model);

        public bool Add(Voiture voiture);
        public bool Update(Voiture voiture);
        public bool Delete(Voiture voiture);
        public bool Save();
    }
}
