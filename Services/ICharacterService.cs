using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Dtos.Character;
using dotnet_test.Models;

namespace dotnet_test.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterResponse>>> GetAllCharacters();
        Task<ServiceResponse<CharacterResponse>> GetCharactereById(int id);
        Task<ServiceResponse<List<CharacterResponse>>> AddCharacter(CharacterRequest newCharacter);
        Task<ServiceResponse<List<CharacterResponse>>> UpdateCharacter(UpdateCharacter updatedCharacter);

        Task<ServiceResponse<List<CharacterResponse>>> DeleteCharacter(int id);

        




    }
}