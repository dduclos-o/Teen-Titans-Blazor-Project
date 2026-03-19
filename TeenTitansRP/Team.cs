using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace TeenTitansRP
{
    public class Team
    {
        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "Your team has no team name set")]
        public string? TeamName { get; set; }

        [Required(ErrorMessage = "Your team has no base name set!")]
        public string? BaseName { get; set; }

        [Required(ErrorMessage = "Your team has no base location set!")]
        public string? BaseLocation { get; set; }

        [Required(ErrorMessage = "Is your team good or evil?")]
        public bool isGood { get; set; }

        [JsonIgnore]
        public List<Character> Characters { get; set; } = new();
    }
}
