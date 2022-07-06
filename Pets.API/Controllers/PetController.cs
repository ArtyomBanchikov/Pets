﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pets.API.Contexts;
using Pets.API.Entities;

namespace Pets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetsContext _context;

        public PetController(PetsContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets.ToList();
        }

        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet == null)
                throw new ArgumentNullException("Object cannot be null", nameof(pet));
            return pet;
        }

        [HttpPost]
        public void Post(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put(Pet request)
        {
            var dbPet = _context.Pets.Find(request.Id);
            if (dbPet == null)
                throw new ArgumentNullException("Object cannot be null", nameof(dbPet));

            dbPet.Age = request.Age;
            dbPet.Weight = request.Weight;
            dbPet.Name = request.Name;

            _context.Entry(dbPet).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var dbPet = _context.Pets.Find(id);
            if(dbPet == null)
                throw new ArgumentNullException("Object cannot be null", nameof(dbPet));

            _context.Pets.Remove(dbPet);
            _context.SaveChanges();
        }
    }
}
