using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Domain.IRepositories
{
    public interface IPetTypeRepositories
    {
        List<PetTypes> GetAllPetTypesList();
        PetTypes GetPetTypesById(int id);
    }
}