using System;

namespace PetShop.Core.Entities
{
    public class Pets
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public PetTypes Type { get; set; }
            public DateTime Birthdate { get; set; }
            public DateTime SoldDate { get; set; }
            public string Color { get; set; }
            public double Price { get; set; }
            
    }
}