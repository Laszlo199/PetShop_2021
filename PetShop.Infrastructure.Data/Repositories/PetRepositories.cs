using System.Collections.Generic;
using PetShop.Core.Entities;
using PetShop.Domain.IRepositories;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepositories: IPetRepositories
    {
            /*Create a new Pet
            Delete Pet 
            Update a Pet
            Sort Pets By Price
            Get 5 cheapest available Pets
            */
        
            private static List<Pets> _petsTable = new List<Pets>();
            private static int id = 1;

            public Pets GetPetsFromId(int id)
            {
                foreach (Pets pet in _petsTable)
                {
                    if (pet.Id == id)
                    {
                        return pet;
                    }
                }

                return null;
            }

            public List<Pets> FindAll(Pets pets)
            {
                return _petsTable;
            }

            public Pets Creat(Pets pets)
            {
                pets.Id = id++;
                _petsTable.Add(pets);
                return pets;
            }

            public Pets Delete(int id)
            {
                var petFound = this.GetPetsFromId(id);
                if (petFound != null)
                {
                    _petsTable.Remove(petFound);
                    return petFound;
                }
                return null;
            }

            public Pets UpdatePets(Pets petsUpdated)
            {
                var petToUpdate = this.GetPetsFromId(petsUpdated.Id);

                if (petToUpdate != null)
                {
                    petToUpdate.Name = petsUpdated.Name;
                    petToUpdate.Type = petsUpdated.Type;
                    petToUpdate.Birthdate = petsUpdated.Birthdate;
                    petToUpdate.SoldDate = petsUpdated.SoldDate;
                    petToUpdate.Color = petsUpdated.Color;
                    petToUpdate.Price = petsUpdated.Price;
                }

                return null;
            }
    }
}