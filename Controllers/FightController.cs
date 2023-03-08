using simple_rpg_fighting_simulator.Dtos.Fight;
using simple_rpg_fighting_simulator.Models;
using simple_rpg_fighting_simulator.Services.FightService;
using Microsoft.AspNetCore.Mvc;

namespace simple_rpg_fighting_simulator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }

        [HttpPost("Weapon")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> WeaponAttack(WeaponAttackDto request) {
            return Ok(await _fightService.WeaponAttack(request));
        }

        [HttpPost("Spell")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> SpellAttack(SpellAttackDto request) {
            return Ok(await _fightService.SpellAttack(request));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<FightResultDto>>> Fight(FightRequestDro request) {
            return Ok(await _fightService.Fight(request));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<HighscoreDto>>>> GetHighscore()
        {
            return Ok(await _fightService.GetHighscore());
        }
    }
}