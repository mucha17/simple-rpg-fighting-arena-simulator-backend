using AutoMapper;
using simple_rpg_fighting_simulator.Dtos.Character;
using simple_rpg_fighting_simulator.Dtos.Fight;
using simple_rpg_fighting_simulator.Dtos.Spell;
using simple_rpg_fighting_simulator.Dtos.Weapon;
using simple_rpg_fighting_simulator.Models;

namespace simple_rpg_fighting_simulator
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Spell, GetSpellDto>();
            CreateMap<Character, HighscoreDto>();
        }
    }
}