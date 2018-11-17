using DungeonsAndCodeWizards.Entities.Characters;
using System;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int WEIGHT = 5;
        private const int RESTORE_POINTS = 20;
        public HealthPotion() : base(weight: WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health = Math.Min(character.BaseHealth, character.Health + RESTORE_POINTS);
        }
    }
}
