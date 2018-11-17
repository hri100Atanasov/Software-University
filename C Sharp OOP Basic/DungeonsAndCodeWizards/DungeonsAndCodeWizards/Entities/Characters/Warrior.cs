using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Enums;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double BASE_HEALHT = 100;
        private const double BASE_ARMOR = 50;
        private const double ABILITY_POINTS = 40;

        public Warrior(string name, Faction faction)
            : base(name, health: BASE_HEALHT, armor: BASE_ARMOR, abilityPoints: ABILITY_POINTS, bag: new Satchel(), faction: faction)
        {
        }

        public void Attack(Character character)
        {
            DeterminIfAlive();

            if (character.Equals(this))
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {character.Faction} faction!");
            }

            character.TakeDamage(ABILITY_POINTS);
        }
    }
}
