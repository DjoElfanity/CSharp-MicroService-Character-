using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Models;

namespace dotnet_test.Dtos.Character
{
    public class UpdateCharacter
    {
        

        public int Id { get; set; }
        public string Name { get; set; } = "Jad";

        public int HitPoints { get; set; }  = 100;

        public int Defense { get; set; }  = 10; 

        public int Intelligence { get; set; } = 10; 

        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}