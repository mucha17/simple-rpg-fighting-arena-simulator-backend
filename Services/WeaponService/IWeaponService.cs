using simple_rpg_fighting_simulator.Dtos.Character;
using simple_rpg_fighting_simulator.Dtos.Weapon;
using simple_rpg_fighting_simulator.Models;

namespace simple_rpg_fighting_simulator.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}