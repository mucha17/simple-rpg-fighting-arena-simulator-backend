using simple_rpg_fighting_simulator.Dtos.Character;
using simple_rpg_fighting_simulator.Models;
using AutoMapper;
using simple_rpg_fighting_simulator.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace simple_rpg_fighting_simulator.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CharacterService(
            IMapper mapper,
            DataContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!
            .User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(
            AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            // create a relationship between the character and the user
            character.User = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == GetUserId());
            
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                await _context.Characters
                // Return only the characters that are owned by the user
                .Where(c => c.User!.Id == GetUserId())
                .Select(c => _mapper.Map<GetCharacterDto>(c))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(
            int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>(); 
            try 
            {
                var character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == id &&
                    // Find the character only if the user is it's owner
                    c.User!.Id == GetUserId());
                if(character is null)
                {
                    throw new Exception($"Character with Id '{id}' not found.");
                }

                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();

                serviceResponse.Data = 
                    await _context.Characters
                    .Where(c => c.User!.Id == GetUserId())
                    .Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters
                .Include(c => c.Weapon)
                .Include(c => c.Spells)
                .Where(c => c.User!.Id == GetUserId())
                .ToListAsync();
            serviceResponse.Data = dbCharacters.Select(
                    c => _mapper.Map<GetCharacterDto>(c)
                ).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters
                .Include(c => c.Weapon)
                .Include(c => c.Spells)
                .FirstOrDefaultAsync(c => c.Id == id && 
                // Find the character only if the user is it's owner
                c.User!.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> PatchCharacter(int id,
            PatchCharacterDto patchedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>(); 
            try 
            {
                var character = await _context.Characters
                    .Include(c => c.User) // Force Entity Framework to get User field from DB if skipped
                    .FirstOrDefaultAsync(c => c.Id == id);
                if(character is null || character.User!.Id != GetUserId())
                {
                    throw new Exception($"Character with Id '{id}' not found.");
                }
                
                if(patchedCharacter.Name is not null) {
                    character.Name = patchedCharacter.Name;
                }
                if(patchedCharacter.HitPoints is not null) {
                    character.HitPoints = (int)patchedCharacter.HitPoints;
                }
                if(patchedCharacter.Strength is not null) {
                    character.Strength = (int)patchedCharacter.Strength;
                }
                if(patchedCharacter.Defense is not null) {
                    character.Defense = (int)patchedCharacter.Defense;
                }
                if(patchedCharacter.Intelligence is not null) {
                    character.Intelligence = (int)patchedCharacter.Intelligence;
                }
                if(patchedCharacter.Class is not null) {
                    character.Class = (RpgClass)patchedCharacter.Class;
                }
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id,
            UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>(); 
            try 
            {
                var character = await _context.Characters
                    .Include(c => c.User) // Force Entity Framework to get User field from DB if skipped
                    .FirstOrDefaultAsync(c => c.Id == id);
                if(character is null || character.User!.Id != GetUserId())
                {
                    throw new Exception($"Character with Id '{id}' not found.");
                }
                
                _mapper.Map(updatedCharacter, character);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSpell(
            AddCharacterSpellDto newCharacterSpell)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c => c.Spells)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterSpell.CharacterId &&
                        c.User!.Id == GetUserId());
                if(character is null) 
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }

                var spell = await _context.Spells
                    .FirstOrDefaultAsync(s => s.Id == newCharacterSpell.SpellId);
                if(spell is null)
                {
                    response.Success = false;
                    response.Message = "Spell not found.";
                    return response;
                }

                character.Spells!.Add(spell);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}