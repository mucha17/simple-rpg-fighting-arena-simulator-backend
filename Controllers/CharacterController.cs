using simple_rpg_fighting_simulator.Dtos.Character;
using simple_rpg_fighting_simulator.Models;
using simple_rpg_fighting_simulator.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simple_rpg_fighting_simulator.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharacters() 
        {
            var response = await _characterService.GetAllCharacters();
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacterById(
            int id) 
        {
            var response = await _characterService.GetCharacterById(id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(
            AddCharacterDto newCharacter) 
        {
            var response = await _characterService.AddCharacter(newCharacter);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(
            int id, UpdateCharacterDto updatedCharacter) 
        {
            var response = await _characterService.UpdateCharacter(id, updatedCharacter);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> PatchCharacter(
            int id, PatchCharacterDto patchedCharacter) 
        {
            var response = await _characterService.PatchCharacter(id, patchedCharacter);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(
            int id) 
        {
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("Spell")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSpell(
            AddCharacterSpellDto newCharacterSpell)
        {
            return Ok(await _characterService.AddCharacterSpell(newCharacterSpell));
        }
    }
}