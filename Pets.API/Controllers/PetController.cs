﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pets.BLL.Interfaces;
using Pets.API.ViewModel;
using Pets.BLL.Models;

namespace Pets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : GenericController<PetViewModel, Pet>
    {
        public PetController(IGenericService<Pet> service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
