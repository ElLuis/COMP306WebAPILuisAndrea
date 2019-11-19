using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP306WebAPILuisAndrea.Models;
using COMP306WebAPILuisAndrea.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COMP306WebAPILuisAndrea.Controllers
{
    [Route("api/[Controller]")]
    //testing github
    public class DrivingController : Controller
    {
        private readonly IDrivingRepository _drivingRepository;
        public DrivingController(IDrivingRepository drivingRepo)
        {
            _drivingRepository = drivingRepo;
        }

        [HttpGet]
        public IEnumerable<DrivingCentre> GetAll()
        {
            return _drivingRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetDrivingCentre")]
        public IActionResult GetById(long id)
        {
            var driving = _drivingRepository.GetById(id);
            if (driving == null)
                return NotFound();

            return new ObjectResult(driving);
        }


        [HttpPost]
        public IActionResult Create([FromBody] DrivingCentre drivingCentre)
        {
            if (drivingCentre == null)
                return BadRequest();

            _drivingRepository.Add(drivingCentre);

            return CreatedAtRoute("GetDrivingCentre", new { id = drivingCentre.AddressId }, drivingCentre);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] DrivingCentre drivingCentre)
        {
            if (drivingCentre == null || drivingCentre.AddressId != id)
                return BadRequest();

            var _drivingCentre = _drivingRepository.GetById(id);

            if (drivingCentre == null)
                return NotFound();

            _drivingCentre.Number = drivingCentre.Number;
            _drivingCentre.Street1 = drivingCentre.Street1;
            _drivingCentre.Street2 = drivingCentre.Street2;
            _drivingCentre.Country = drivingCentre.Country;
            _drivingCentre.Province = drivingCentre.Province;
            _drivingCentre.District = drivingCentre.District;
            _drivingCentre.City = drivingCentre.City;
            _drivingCentre.ZipCode = drivingCentre.ZipCode;

            _drivingRepository.Update(_drivingCentre);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var drivingCentre = _drivingRepository.GetById(id);

            if (drivingCentre == null)
                return NotFound();

            _drivingRepository.Remove(id);

            return new NoContentResult();
        }
    }
}
