using simple_rpg_fighting_simulator.Models;

namespace simple_rpg_fighting_simulator.Dtos.Character
{
    public class PatchCharacterDto
    {
        public string? Name { get; set; }
        public int? HitPoints { get; set; }
        public int? Strength { get; set; }
        public int? Defense { get; set; }
        public int? Intelligence { get; set; }
        public RpgClass? Class { get; set; }
    }
}