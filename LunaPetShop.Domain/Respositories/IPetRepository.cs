using System;
using System.Collections.Generic;
using LunaPetShop.Domain.Entities;

namespace LunaPetShop.Domain.Repository
{
    public interface IPetRepository
    {
        List<Pet> GetAllByEmail(string Email);
        List<Pet> GetPetByUserId(Guid Id);
        Pet GetPetById(Guid Id);
        void DeletePet(Pet pet);
        void UpdatePet(Pet pet);

    }
}