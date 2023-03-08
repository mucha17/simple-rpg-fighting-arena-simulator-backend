using simple_rpg_fighting_simulator.Dtos.Character;
using simple_rpg_fighting_simulator.Models;

namespace simple_rpg_fighting_simulator.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(
            AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id,
            UpdateCharacterDto updatedCharacter);
        Task<ServiceResponse<GetCharacterDto>> PatchCharacter(int id,
            PatchCharacterDto patchedCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSpell(AddCharacterSpellDto newCharacterSpell);
    }
}