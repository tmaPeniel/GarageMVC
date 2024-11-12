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

        public bool Add(Voiture voiture)
        {
            _context.Add(voiture);
            return Save();
        }

        public bool Delete(Voiture voiture)
        {
            _context.Remove(voiture);
            return Save();
        }

        public async Task<List<Voiture>> GetAllAsync()
        {
            return await _context.Voitures.ToListAsync();
        }

        public async Task<Voiture> GetVoitureByIdAsync(string id)
        {
            return await _context.Voitures.FirstOrDefaultAsync(x => x.Immatriculation.Contains(id));
        }

        public async Task<List<Voiture>> GetVoitureByMarque(string marque)
        {
            return await _context.Voitures.Where(x => x.Marque.Contains(marque)).ToListAsync();
        }

        public async Task<List<Voiture>> GetVoituresByModel(string model)
        {
            return await _context.Voitures.Where(x => x.Modele.Contains(model)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Voiture voiture)
        {
            _context.Update(voiture);
            return Save();
        }
    }
}
