using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Dtos.Character;
using dotnet_test.Models;
using dotnet_test.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character { Id = 1, Name = "Ali" }
        };

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<CharacterResponse>>>> GetAllCharacters()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CharacterResponse>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharactereById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CharacterResponse>>>> AddChar(CharacterRequest newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<CharacterResponse>>>> UpdateChar(UpdateCharacter updateCharacter)
        {
            var response = await _characterService.UpdateCharacter(updateCharacter);
            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }


       [HttpDelete("{id}")]
            public async Task<ActionResult<ServiceResponse<List<CharacterResponse>>>> DeleteCharacter(int id)
            {
                var serviceResponse = await _characterService.DeleteCharacter(id);

                if (!serviceResponse.Success)
                {
                    return BadRequest(serviceResponse);
                }

                return Ok(serviceResponse);
            }
    }
}
