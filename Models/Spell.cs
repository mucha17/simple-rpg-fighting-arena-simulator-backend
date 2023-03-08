namespace simple_rpg_fighting_simulator.Models
{
    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public List<Character>? Characters { get; set; }
    }
}