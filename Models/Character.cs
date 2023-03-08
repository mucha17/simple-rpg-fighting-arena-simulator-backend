namespace simple_rpg_fighting_simulator.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Unnamed";
        public int HitPoints { get; set; } = 10;
        public int Strength { get; set; } = 1;
        public int Defense { get; set; } = 1;
        public int Intelligence { get; set; } = 1;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public User? User { get; set; }
        public Weapon? Weapon { get; set; }
        public List<Spell>? Spells { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}