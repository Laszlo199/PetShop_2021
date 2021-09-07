using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.IServices
{
    public interface IPetTypeServices
    {
        List<PetTypes> GetAllPetTypesList();
        PetTypes GetPetTypesById(int id);
    }
}