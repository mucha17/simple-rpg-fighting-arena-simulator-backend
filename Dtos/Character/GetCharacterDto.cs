using simple_rpg_fighting_simulator.Dtos.Spell;
using simple_rpg_fighting_simulator.Dtos.Weapon;
using simple_rpg_fighting_simulator.Models;

namespace simple_rpg_fighting_simulator.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgClass Class { get; set; }
        public GetWeaponDto? Weapon { get; set; }
        public List<GetSpellDto>? Spells { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}