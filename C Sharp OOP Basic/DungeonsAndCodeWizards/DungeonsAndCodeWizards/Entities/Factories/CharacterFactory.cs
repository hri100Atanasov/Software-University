using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Factories
{
   public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            if (!Enum.TryParse<Faction>(faction, out var factionParsed))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            //switch (type)
            //{
            //    case "Warrior":
            //        return new Warrior(name, factionParsed);
            //    case "Cleric":
            //        return new Cleric(name, factionParsed);
            //    default:
            //        throw new ArgumentException($"Invalid character type \"{type}\"!");
            //}

            var classType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            if (classType == null)
            {
                throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            Character character = (Character)Activator.CreateInstance(classType, name, factionParsed);

            return character;
        }
    }
}
