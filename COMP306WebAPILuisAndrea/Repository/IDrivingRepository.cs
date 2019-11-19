using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP306WebAPILuisAndrea.Models;

namespace COMP306WebAPILuisAndrea.Repository
{
    public interface IDrivingRepository
    {
        void Add(DrivingCentre driving);
        IEnumerable<DrivingCentre> GetAll();
        DrivingCentre GetById(long id);
        void Remove(long id);
        void Update(DrivingCentre driving);
    }
}
