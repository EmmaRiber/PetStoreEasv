using PetShop.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.DomainService
{
    interface IPetRepository
    {
        //PetRepository Interface
        //Create Data
        Pet Create(Pet pet);
        //Read Data
        Pet ReadyById(int id);
        //Update Data
        Pet Update(Pet petUpdate);
        //Delete Data
        Pet delete(int id);
        //CRUD
    }
}
