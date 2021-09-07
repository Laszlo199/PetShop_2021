using System;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.IServices;
using PetShop.Domain.IRepositories;
using PetShop.Domain.Services;
using PetShop.Infrastructure.Data.Repositories;

namespace CrashCourse_PetShop_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetRepositories petRepo = new PetRepositories();
            IPetTypeRepositories petTypeRepo = new PetTypeRepositories();
            
            IPetServices service = new PetService(petRepo);
            IPetTypeServices pTypeService = new PetTypeService(petTypeRepo);
            
            Menu menu = new Menu(service, pTypeService);
            menu.StartUI();


        }
    }
}