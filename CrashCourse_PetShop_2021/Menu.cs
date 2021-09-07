using System;
using PetShop.Core.IServices;

namespace CrashCourse_PetShop_2021
{
    public class Menu: IMenu
    {
        private IPetServices _services;
        private IPetTypeServices _typeServices;

        public Menu(IPetServices services, IPetTypeServices typeServices)
        {
            _services = services;
            _typeServices = typeServices;
            StartUI();
        }


        public void StartUI()
        {
            Console.WriteLine("TOPKAA");
            Console.ReadLine();
        }
    }
}