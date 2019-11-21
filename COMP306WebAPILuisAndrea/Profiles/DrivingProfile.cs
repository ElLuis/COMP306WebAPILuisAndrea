using AutoMapper;
using COMP306WebAPILuisAndrea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306WebAPILuisAndrea.Profiles
{
    public class DrivingProfile : Profile
    {
        public DrivingProfile()
        {
            CreateMap<DrivingCentre, DrivingCentreViewModel>();
        }
    }
}
