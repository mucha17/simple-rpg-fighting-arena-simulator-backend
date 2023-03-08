using simple_rpg_fighting_simulator.Models;

namespace simple_rpg_fighting_simulator.Dtos.Character
{
    public class UpdateCharacterDto
    {
        public string Name { get; set; } = "Unnamed";
        public int HitPoints { get; set; } = 10;
        public int Strength { get; set; } = 1;
        public int Defense { get; set; } = 1;
        public int Intelligence { get; set; } = 1;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}