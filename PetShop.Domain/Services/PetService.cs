using System.Collections.Generic;
using PetShop.Core.Entities;
using PetShop.Core.IServices;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class PetService: IPetServices
    {
        private IPetRepositories _repo;

        public PetService(IPetRepositories repo)
        {
            _repo = repo;
        }
        public Pets GetPetsFromId(int id)
        {
            return _repo.GetPetsFromId(id);
        }

        public List<Pets> FindAll(Pets pets)
        {
            return _repo.FindAll(pets);
        }

        public Pets Creat(Pets pets)
        {
            return _repo.Creat(pets);
        }

        public Pets Delete(int id)
        {
            return _repo.Delete(id);
        }

        public Pets UpdatePets(Pets petsUpdated)
        {
            return _repo.UpdatePets(petsUpdated);
        }
    }
}