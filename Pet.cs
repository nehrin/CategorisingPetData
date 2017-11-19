using Newtonsoft.Json;

namespace CategorisingDataForPets
{
    public class Pet
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }

        public Pet(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
      
    }
}
