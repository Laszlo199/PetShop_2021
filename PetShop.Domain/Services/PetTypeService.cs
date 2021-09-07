using System.Collections.Generic;
using PetShop.Core.Entities;
using PetShop.Core.IServices;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class PetTypeService: IPetTypeServices
    {
        private IPetTypeRepositories _repo;

        public PetTypeService(IPetTypeRepositories repo)
        {
            _repo = repo;
        }

        public List<PetTypes> GetAllPetTypesList()
        {
            return _repo.GetAllPetTypesList();
        }

        public PetTypes GetPetTypesById(int id)
        {
            return _repo.GetPetTypesById(id);
        }
    }
}