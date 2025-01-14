﻿using System;
using System.Collections.Generic;
using System.Linq;
using PetApi.Models;

namespace PetApi.Services
{
    public class PetsService : IPetsService
    {
        private IList<Pet> _pets;

        public PetsService()
        {
            _pets = new List<Pet>();
        }

        public Pet CreatePet(Pet pet)
        {
            _pets.Add(pet);
            return pet;
        }

        public IList<Pet> GetAllPets()
        {
            return _pets;
        }

        public Pet? GetByName(string name)
        {
            return _pets.FirstOrDefault(_ => _.Name.Equals(name));
        }

        public bool DeleteByName(string name)
        {
            var pet = GetByName(name);
            if (pet != null)
            {
                return _pets.Remove(pet);
            }
            
            return false;
        }

        public Pet? ModifyPetPrice(string name, PetPriceChangeDto priceChange)
        {
            var pet = GetByName(name);
            if (pet != null)
            {
                pet.Price = priceChange.Price;
            }

            return pet;
        }

        public IList<Pet> GetByType(PetType type)
        {
            return _pets.Where(_ => _.Type == type).ToList();
        }

        public IList<Pet>? GetByPriceRange(double from, double to)
        {
            return _pets.Where(_ => _.Price <= to && _.Price >= from).ToList();
        }

        public IList<Pet>? GetByColor(string color)
        {
            return _pets.Where(_ => _.Color.Equals(color, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public bool DeleteAll()
        {
            _pets.Clear();
            return true;
        }
    }
}
