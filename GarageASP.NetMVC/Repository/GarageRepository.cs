using GarageASP.NetMVC.Interfaces;
using GarageASP.NetMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GarageASP.NetMVC.Repository
{
    public class GarageRepository : IGarageManagement
    {
        private readonly GarageManagementContext _context;
        
        public GarageRepository(GarageManagementContext context)
        {
            _context = context;
            
        }
        public bool CarExists(string id)
        {
            return _context.Voitures.Any(c => c.Immatriculation == id);
        }

        public bool Add(Car voiture)
        {
            _context.Add(voiture);
            return Save();
        }

        public bool Delete(Car voiture)
        {
            _context.Remove(voiture);
            return Save();
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await _context.Voitures.Include(c=>c.Client).ToListAsync(); //Si j'associe à une table et que je veux les deux infos (Voiture et client)
        }

        public async Task<Car> GetVoitureByIdAsync(string id)
        {
            return await _context.Voitures.Where(x => x.Immatriculation.Contains(id)).Include(c=>c.Client).FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetVoitureByMarque(string marque)
        {
            return await _context.Voitures.Where(x => x.Marque.Contains(marque)).ToListAsync();
        }

        public async Task<List<Car>> GetVoituresByModel(string model)
        {
            return await _context.Voitures.Where(x => x.Modele.Contains(model)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Car voiture)
        {
            _context.Update(voiture);
            return Save();
        }

       
    }
}
