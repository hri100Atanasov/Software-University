using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Enums;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double BASE_HEALHT = 50;
        private const double BASE_ARMOR = 25;
        private const double ABILITY_POINTS = 40;

        public Cleric(string name, Faction faction)
            : base(name, health: BASE_HEALHT, armor: BASE_ARMOR, abilityPoints: ABILITY_POINTS, bag: new Backpack(), faction:faction)
        {
        }

        public void Heal(Character character)
        {
            DeterminIfAlive();
            if (Faction!=character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health = Math.Min(character.BaseHealth, character.Health + ABILITY_POINTS);
        }

        public override double RestHealMultiplier => 0.5;
    }
}
