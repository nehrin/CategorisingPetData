using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CategorisingDataForPets
{
    public class Person
    {
        [JsonProperty("gender")]
        public Gender Gender { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("pets")]
        public List<Pet> Pets { get; set; }

        public Person(string name, int age, Gender gender)
        {
            Gender = gender;
            Name = name;
            Age = age;
        }
    }

    public enum Gender
    {
        [JsonProperty("female")]
        Female,
        [JsonProperty("male")]
        Male
    }
}
