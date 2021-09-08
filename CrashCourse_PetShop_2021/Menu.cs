using System;
using System.Collections.Generic;
using PetShop.Core.Entities;
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
            
            int selection;
            do
            {
                selection = MainManuSelection();
                switch (selection)
                {
                    case 1:
                        GetAllPets();
                        break;
                    case 2:
                       CreateNewPet();
                        break;
                    case 3:
                        DeletePet();
                        break;
                    case 4:
                        UpdatePet();
                        break;
                }
                Console.ReadKey();
            } while (selection != 0);

        }

        private void UpdatePet()
        {
            GetAllPets();
            Console.WriteLine("");
            var idForEdit = PrintFindCustomerById();
            var petToEdit = _services.GetPetsFromId(idForEdit);
            Console.WriteLine("Updating: "+ petToEdit.Name + petToEdit.Type + petToEdit.Birthdate + petToEdit.SoldDate + petToEdit.Color + petToEdit.Price);
            //Name
            Console.WriteLine(StringConstants.EditPetName);
            var newName = Console.ReadLine();
            //Type
            Console.WriteLine(StringConstants.EditPetType);
            int newType = int.Parse(Console.ReadLine());
            //Birthdate
            Console.WriteLine(StringConstants.EditPetBirthdate);
            DateTime newBirthdate = DateTime.Parse(Console.ReadLine());
            //SoldDate
            Console.WriteLine(StringConstants.EditPetSoldDate);
            DateTime newSoldDate = DateTime.Parse(Console.ReadLine());
            //Color
            Console.WriteLine(StringConstants.EditPetColor);
            var newColor = Console.ReadLine();
            //Price
            Console.WriteLine(StringConstants.EditPetPrice);
            double newPrice = int.Parse(Console.ReadLine());
            Pets pet = new Pets()
            {
                Id = idForEdit,
                Name = newName,
                Type = _typeServices.GetPetTypesById(newType),
                Birthdate = newBirthdate,
                SoldDate = newSoldDate,
                Color = newColor,
                Price = newPrice
            };
            pet = _services.UpdatePets(pet);
            Console.WriteLine($"{pet.Id} Successfully Edited.");
        }
        
        private int PrintFindCustomerById()
        {
            Console.WriteLine("Insert Pet id: ");
            int id;
            
            while (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Pls insert a number!!");
            }

            return id;
        }
        
        private void DeletePet()
        {
            Console.WriteLine(StringConstants.DeletetextHead);
            GetAllPets();
            var petId = Console.ReadLine();
            int selection = Int32.Parse(petId);
            if (!Int32.TryParse(petId, out int petIdInt))
            {
                Console.WriteLine("Nope");
            }
            else
            {
                var pet = _services.Delete(selection);
                Console.WriteLine($"{pet.Name} Successfully Deleted.");
            }

        }

        private void CreateNewPet()
        {
            Console.WriteLine(StringConstants.AddText);
            //Name
            Console.WriteLine("\n");
            Console.WriteLine(StringConstants.PetName);
            string petName = Console.ReadLine();
            //Type
            Console.WriteLine(StringConstants.PetType);
            GetAllPetTypes();
            string petType = Console.ReadLine();
            int typeSelection;
            while (!int.TryParse(petType,out typeSelection) || typeSelection > _typeServices.GetAllPetTypesList().Count)
            {
                Console.WriteLine(StringConstants.AddPetError);
                petType = Console.ReadLine();
            }
            //BirthDay
            Console.WriteLine(StringConstants.PetBirthdate);
            DateTime birthDay = DateTime.Today;
            //Color
            Console.WriteLine(StringConstants.PetColor);
            string petColor = Console.ReadLine();
            //Price
            Console.WriteLine(StringConstants.PetPrice);
            double price = int.Parse(Console.ReadLine());

            Pets pet = new Pets()
            {
                Name = petName,
                Type = _typeServices.GetPetTypesById(typeSelection),
                Birthdate = birthDay,
                Color = petColor,
                Price = price
            };
            pet =_services.Creat(pet);
            Console.WriteLine($"{pet.Name} Successfully added.");
           
        }

        private void GetAllPets()
        {
            Console.WriteLine(StringConstants.ListOfAllPets);
            Console.WriteLine("\n");
            var pet = _services.FindAll();
            foreach (Pets pets in pet)
            {
                Console.WriteLine($"ID: {pets.Id} \nName: {pets.Name} \nType: {pets.Type.Name} \nBirthdate: {pets.Birthdate} \nColor: {pets.Color} \nPrice: {pets.Price}.dkk \nSoldDate: {pets.SoldDate}");
                
                Console.WriteLine("\n");
                Console.WriteLine("------------------------");
            }
            
            Console.WriteLine("\n");
        }

        private int MainManuSelection()
        {
            int selection;
            do
            {
                ShowMenu();
                var selectedOption = Console.ReadKey();
                selection = selectedOption.KeyChar - '0';
                if (selection< 0 || selection > 4)
                {
                    Console.WriteLine(StringConstants.MenuSelectionError);
                }
                
            } while (selection< 0 || selection > 4);

            return selection;
        }

        private void ShowMenu()
        {
            Console.WriteLine(StringConstants.AllPetsMenu);
            Console.WriteLine(StringConstants.AddNewPet);
            Console.WriteLine(StringConstants.DeletePet);
            Console.WriteLine(StringConstants.EditPet);
            Console.WriteLine(StringConstants.Exit);
            Console.WriteLine("\n");
        }

        public void GetAllPetTypes()
        {
            var petType = _typeServices.GetAllPetTypesList();
            foreach (PetTypes pType in petType)
            {
                Console.WriteLine($"ID: {pType.Id} | {pType.Name}");
            }
        }
        

        
    }
    
}