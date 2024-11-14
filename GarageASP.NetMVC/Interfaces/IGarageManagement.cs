using GarageASP.NetMVC.Models;

namespace GarageASP.NetMVC.Interfaces
{
    public interface IGarageManagement
    {
        public Task<List<Car>> GetAllAsync();
        public Task<Car> GetVoitureByIdAsync(string id);

        public Task<List<Car>> GetVoitureByMarque(string marque);
        public Task<List<Car>> GetVoituresByModel(string model);

        public bool Add(Car voiture);
        public bool Update(Car voiture);
        public bool Delete(Car voiture);
        public bool Save();
    }
}
