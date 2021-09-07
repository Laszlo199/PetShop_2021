using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.IServices
{
    public interface IPetServices
    {
        Pets GetPetsFromId(int id);
        List<Pets> FindAll();
        Pets Creat(Pets pets);
        Pets Delete(int id);
        Pets UpdatePets(Pets petsUpdated);
    }
}