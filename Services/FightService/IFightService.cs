using simple_rpg_fighting_simulator.Dtos.Fight;
using simple_rpg_fighting_simulator.Models;

namespace simple_rpg_fighting_simulator.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
        Task<ServiceResponse<AttackResultDto>> SpellAttack(SpellAttackDto request);
        Task<ServiceResponse<FightResultDto>> Fight(FightRequestDro request);
        Task<ServiceResponse<List<HighscoreDto>>> GetHighscore();
    }
}