using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_test.Dtos.Character;
using dotnet_test.Models;

namespace dotnet_test.Mapping
{
    public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Character, CharacterResponse>();
        CreateMap<CharacterRequest, Character>();
    }
}
}