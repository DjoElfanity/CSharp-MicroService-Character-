using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_test.Dtos.Character;
using dotnet_test.Models;

namespace dotnet_test.Services
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character { Id = 1, Name = "Ali" }
        };

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ServiceResponse<List<CharacterResponse>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponse>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<CharacterResponse>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterResponse>> GetCharactereById(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterResponse>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            

            if (character == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Personnage introuvable.";
            }
            else
            {
                
                serviceResponse.Data = _mapper.Map<CharacterResponse>(character);
            }

            return serviceResponse;
        }

         public async Task<ServiceResponse<List<CharacterResponse>>> AddCharacter(CharacterRequest newCharacter)
{
                var serviceResponse = new ServiceResponse<List<CharacterResponse>>();

                if (newCharacter != null)
                {
                    var mappedCharacter = _mapper.Map<Character>(newCharacter);

                    // Trouver le prochain ID disponible en incrémentant le maximum existant
                    mappedCharacter.Id = characters.Max(c => c.Id) + 1;

                    characters.Add(mappedCharacter);
                    serviceResponse.Data = characters.Select(c => _mapper.Map<CharacterResponse>(c)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Le nouveau personnage est null.";
                }

    return serviceResponse;
}

       
    public async Task<ServiceResponse<List<CharacterResponse>>> UpdateCharacter(UpdateCharacter updatedCharacter)
{
    var serviceResponse = new ServiceResponse<List<CharacterResponse>>();
    var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

    if (character == null)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = "Personnage introuvable.";
    }
    else
    {
        character.Name = updatedCharacter.Name;
        character.HitPoints = updatedCharacter.HitPoints;
        character.Defense = updatedCharacter.Defense;
        character.Intelligence = updatedCharacter.Intelligence;
        character.Class = updatedCharacter.Class;

        serviceResponse.Data = characters.Select(c => _mapper.Map<CharacterResponse>(c)).ToList();
    }

    return serviceResponse;
}

        public async Task<ServiceResponse<List<CharacterResponse>>> DeleteCharacter(int id)
            {
                var serviceResponse = new ServiceResponse<List<CharacterResponse>>();
                var character = characters.FirstOrDefault(c => c.Id == id);

                if (character == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Personnage introuvable.";
                    return serviceResponse;
                }

                characters.Remove(character);
                serviceResponse.Data = characters.Select(c => _mapper.Map<CharacterResponse>(c)).ToList();
                return serviceResponse;
            }
    }
    }
