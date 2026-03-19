namespace TeenTitansRP.API.Services
{
    public class TeamBuilder
    {
        public IList<Team> teams = new List<Team>();
        public IList<Power> powers = new List<Power>();
        public IList<Character> characters = new List<Character>();

        public TeamBuilder()
        {
            ConstructTeams();
            ConstructPowers();
            ConstructCharacters();
            //AssignTeams();
        }

        public void ConstructTeams()
        {
            teams.Add(new Team { TeamName = "Hive Five", BaseName = "Hive Tower", BaseLocation = "Earth", isGood = false });
            teams.Add(new Team { TeamName = "Teen Titans", BaseName = "Titan Tower", BaseLocation = "Earth", isGood = true });
        }

        public void ConstructPowers()
        {
            foreach (string power in new Power().powerList)
            {
                powers.Add(new Power { PowerType = power });
            }
        }

        public void ConstructCharacters()
        {
            characters.Add(new Character { Alias = "Robin", Homeworld = "Earth", Species = "Human", isHero = true, Power = powers[new Random().Next(0, powers.Count)] });
            characters.Add(new Character { Alias = "Starfire", Homeworld = "Tamaran", Species = "Tamaranean", isHero = true, Power = powers[new Random().Next(0, powers.Count)] });
            characters.Add(new Character { Alias = "Raven", Homeworld = "Azarath", Species = "Human/Demon Hybrid", isHero = true, Power = powers[new Random().Next(0, powers.Count)] });
            characters.Add(new Character { Alias = "Cyborg", Homeworld = "Earth", Species = "Human/Cyborg Hybrid", isHero = true, Power = powers[new Random().Next(0, powers.Count)] });
            characters.Add(new Character { Alias = "Beast Boy", Homeworld = "Earth", Species = "Metahuman", isHero = true, Power = powers[new Random().Next(0, powers.Count)] });

            characters.Add(new Character { Alias = "Gizmo", Homeworld = "Earth", Species = "Human", isHero = false, Power = powers[new Random().Next(0, powers.Count)] });
            characters.Add(new Character { Alias = "Jinx", Homeworld = "Earth", Species = "Metahuman", isHero = false, Power = powers[new Random().Next(0, powers.Count)] });
            characters.Add(new Character { Alias = "Mammoth", Homeworld = "Earth", Species = "Giant", isHero = false, Power = powers[new Random().Next(0, powers.Count)] });
        }

        //public void AssignTeams()
        //{
        //    foreach (Character c in characters)
        //    {
        //        c.Team = c.isHero == true ? teams.First(x => x.isGood == true) : teams.First(x => x.isGood == false);
        //    }
        //}
    }
}
