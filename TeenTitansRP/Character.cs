using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace TeenTitansRP
{
    public class Character
    {
        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "Your character has no alias set!")]
        public string? Alias { get; set; }

        [Required(ErrorMessage = "Your character has no species set!")]
        public string? Species { get; set; }

        [Required(ErrorMessage = "Your character has no homeworld set!")]
        public string? Homeworld { get; set; }

        [Required(ErrorMessage = "Is your character a hero or a villain?")]
        public bool isHero { get; set; }

        [JsonIgnore]
        public int? PowerId { get; set; }

        [JsonIgnore]
        public Power? Power { get; set; }

        [JsonIgnore]
        public int? TeamId { get; set; }

        [JsonIgnore]
        public Team? Team { get; set; }
    }
}
