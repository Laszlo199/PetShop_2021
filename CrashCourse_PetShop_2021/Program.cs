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
            /*var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepositories, PetRepositories>();
            serviceCollection.AddScoped<IPetTypeRepositories, PetTypeRepositories>();
            serviceCollection.AddScoped<IPetServices, PetService>();
            serviceCollection.AddScoped<IPetServices, PetService>();
            serviceCollection.AddScoped<IMenu, Menu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var menu = serviceProvider.GetRequiredService<IMenu>();
            */
            
            
            IPetRepositories petRepo = new PetRepositories();
            IPetTypeRepositories petTypeRepo = new PetTypeRepositories();
            
            IPetServices service = new PetService(petRepo);
            IPetTypeServices pTypeService = new PetTypeService(petTypeRepo);
            
            Menu menu = new Menu(service, pTypeService);
            menu.StartUI();


        }
    }
}