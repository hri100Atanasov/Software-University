using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Enums;
using DungeonsAndCodeWizards.Entities.Items;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            Name = name;
            Health = health;
            BaseHealth = health;
            Armor = armor;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Faction = faction;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }
        public bool IsAlive { get; set; } = true;
        public double Health { get; set; }
        public double BaseHealth { get; set; }
        public double Armor { get; set; }
        public double BaseArmor { get; set; }
        public double AbilityPoints { get; set; }
        public Bag Bag { get; set; }
        public virtual double RestHealMultiplier { get; set; } = 0.2;
        public Faction Faction { get; set; }

        public void TakeDamage(double hitPoints)
        {
            DeterminIfAlive();

            Armor -= hitPoints;
            if (Armor < 0)
            {
                Health += Armor;
                Armor = 0;
            }

            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }

        public void Rest()
        {
            DeterminIfAlive();
            Health = Math.Min(BaseHealth, Health + (BaseHealth * RestHealMultiplier));
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            character.UseItem(item);
        }

        public void GiveCharacterItem(Item item, Character character)
        {

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            Bag.AddItem(item);
        }

        public void DeterminIfAlive()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            var alive = "Alive";
            var dead = "Dead";
            var status = IsAlive ? alive : dead;
            return $"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {status}";
        }
    }
}
