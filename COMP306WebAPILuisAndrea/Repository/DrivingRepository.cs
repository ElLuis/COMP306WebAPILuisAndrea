using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP306WebAPILuisAndrea.Models;

namespace COMP306WebAPILuisAndrea.Repository
{
    public class DrivingRepository : IDrivingRepository
    {
        private readonly DrivingDbContext _context;

        public DrivingRepository(DrivingDbContext ctx)
        {
            _context = ctx;
        }

        public void Add(DrivingCentre driving)
        {
            _context.DrivingCentres.Add(driving);
            _context.SaveChanges();
        }

        public DrivingCentre GetById(long id)
        {
            return _context.DrivingCentres.FirstOrDefault(d => d.AddressId == id);

        }

        public IEnumerable<DrivingCentre> GetAll()
        {
            return _context.DrivingCentres.ToList();
        }

        public void Remove(long id)
        {
            var entity = _context.DrivingCentres.First(d => d.AddressId == id);
            _context.DrivingCentres.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(DrivingCentre driving)
        {
            _context.DrivingCentres.Update(driving);
            _context.SaveChanges();
        }
    }
}
