namespace simple_rpg_fighting_simulator.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public Character? Character { get; set; }
        public int CharacterID { get; set; }
    }
}