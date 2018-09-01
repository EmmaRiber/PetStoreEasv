using PetShop.Menu.Core.Entity;
using System;
using System.Collections.Generic;


namespace PetShop
{
    class Printer
    {
        static int Id = 1;
        static List<Pet> pets = new List<Pet>();

        static void Main(string[] args)
        {
            string[] mainMenuItems =
            {
                "List all Pets",
                "Search Pets by Type",
                "Create a new Pet",
                "Delete a Pet",
                "Update a Pet",
                "Sort Pets by price",
                "Get 5 cheapest available Pets"
            };

            Console.WriteLine("Pet Menu ");

            var selection = ShowMenu(mainMenuItems);

            while (selection != 7)
            {
                switch (selection)
                {
                    case 1:
                        ListPets();
                        break;
                    case 2:
                        Console.WriteLine("Search Pets by Type");
                        break;
                    case 3:
                        Console.WriteLine("Create a new Pet");
                        break;
                    case 4:
                        Console.WriteLine("Delete a Pet");
                        break;
                    case 5:
                        UpdatePet();
                        break;
                    case 6:
                        Console.WriteLine("Sort Pets by price");
                        break;
                    case 7:
                        Console.WriteLine("Get 5 cheapest available Pets");
                        break;
                }
                selection = ShowMenu(mainMenuItems);
            }
        }

        static void UpdatePet()
        {
            ListPets();
            Console.WriteLine("Insert the Id you want to edit Pet: ");
            var pet = FindPetById();
            Console.WriteLine("New Pet");
            pet.Name = Console.ReadLine();
        }


        //Finder Id'en for den video, som skal slettes
        static Pet FindPetById()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            foreach (var pet in pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        //Sletter en video fra listen
        static void DeletePet()
        {
            ListPets();
            Console.WriteLine("Insert the Id you want to delete: ");
            var petFound = FindPetById();
            if (petFound != null)
            {
                pets.Remove(petFound);
            }
        }

        //Så kan brugeren add en video til listen
        static void AddPets()
        {
            Console.WriteLine("Name");
            var name = Console.ReadLine();

            pets.Add(new Pet()
            {
                Id = Id++,
                Name = name
            });
        }

        //Viser en liste af videoer
        //
        static void ListPets()
        {
            Console.WriteLine("List of Pets");

            //GetPets() from PetService
            //PetService need a way - GetAll() from PetRepository
            foreach (var pet in pets)
            {
                Console.WriteLine($" id: {pet.Id} Name: {pet.Name}");
            }
            Console.WriteLine(" ");
        }

        //Viser menuen, hvis man har valgt et tal mellem 1-7
        static int ShowMenu(string[] mainMenuItems)
        {
            Console.WriteLine("  ");
            Console.WriteLine("Select what you want to do: ");
            Console.WriteLine(" ");

            for (int i = 0; i < mainMenuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)} : {mainMenuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 7)
            {
                Console.WriteLine("Select a number between 1-7");
            }
            return selection;
        }
    }
}