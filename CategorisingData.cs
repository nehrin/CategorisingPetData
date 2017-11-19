using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace CategorisingDataForPets
{
    public class CategorisingData
    {

        public CategorisingData() { }

        public CategorisingData(string url)
        {
            WebClient wc = new WebClient();
            var json = (JArray)JsonConvert.DeserializeObject(wc.DownloadString(url));
            List<Person>  people = new List<Person>();
            foreach (var p in json)
            {
                Person person = JsonConvert.DeserializeObject<Person>(p.ToString());
                people.Add(person);
            }
            PrintPetsByOwnerGender(Gender.Male, people);
            PrintPetsByOwnerGender(Gender.Female, people);
        }

        public void PrintPetsByOwnerGender(Gender ownerGender, List<Person> people)
        {
            Console.WriteLine(ownerGender.ToString());
            List<Pet> ownerPetsList = GetPetsListOrderedAlphabeticallyByOwnerGender(ownerGender, people);
            ownerPetsList.ForEach(x => Console.WriteLine("\t-" + x.Name));
            Console.WriteLine("\n");
        }
       
        public List<Pet> GetPetsListOrderedAlphabeticallyByOwnerGender(Gender gender, List<Person> people)
        {
            List<Person> ownerList = people.Where(x => x.Gender == gender).ToList();
            List<Pet> ownerPetsList = new List<Pet>();

            foreach (var p in ownerList)
            {
                if (p.Pets != null) ownerPetsList.AddRange(p.Pets);
            }

            return ownerPetsList.OrderBy(x => x.Name).ToList();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("A list of all the cats in alphabetical order under a heading of the gender of their owner:");
            var categorisingData = new CategorisingData("https://agl-developer-test.azurewebsites.net/people.json");
        }

    }
}
