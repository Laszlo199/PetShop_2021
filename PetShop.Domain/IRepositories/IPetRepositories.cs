using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Domain.IRepositories
{
    public interface IPetRepositories
    {
        Pets GetPetsFromId(int id);
        List<Pets> FindAll(Pets pets);
        Pets Creat(Pets pets);
        Pets Delete(int id);
        Pets UpdatePets(Pets petsUpdated);
        
    }
}