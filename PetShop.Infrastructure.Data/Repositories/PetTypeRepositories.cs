using System;
using System.Collections.Generic;
using PetShop.Core.Entities;
using PetShop.Domain.IRepositories;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetTypeRepositories: IPetTypeRepositories
    {
        private static List<PetTypes> _petTypesList = new List<PetTypes>();

        public PetTypeRepositories()
        {
            PetTypes cat = new PetTypes()
            {
                Id = 1,
                Name = "Cat"
            };

            PetTypes dog = new PetTypes()
            {
                Id = 2,
                Name = "Dog"
            };

            PetTypes goat = new PetTypes()
            {
                Id = 3,
                Name = "Goat"
            };
            
            _petTypesList.AddRange(new List<PetTypes>
            {
                cat,
                dog,
                goat
            });
        }
        
        public List<PetTypes> GetAllPetTypesList()
        {
            return _petTypesList;
        }

        public PetTypes GetPetTypesById(int id)
        {
            foreach (PetTypes types in _petTypesList)
            {
                if (types.Id == id)
                {
                    return types;
                }
            }

            return null;
        }
    }
}