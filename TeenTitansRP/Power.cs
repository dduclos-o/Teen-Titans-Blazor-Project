using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TeenTitansRP
{
    public class Power
    {
        public List<String> powerList = new List<String> { "Invisibility", "Super-Strength", "Shapeshifting", "Super Speed", "Pyrokinesis", "Super Intelligence", "Clairvoyance", "Shadow Manipulation", "Cryokinesis", "Hydrokinesis" };

        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "Your power has no power type set!")]
        public string? PowerType { get; set; }
    }
}
 