using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Factories;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private readonly CharacterFactory characterFactory;
        private readonly ItemFactory itemFactory;

        private readonly List<Character> party;
        private readonly Stack<Item> itemPool;

        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            characterFactory = new CharacterFactory();
            itemFactory = new ItemFactory();
            party = new List<Character>();
            itemPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var type = args[1];
            var name = args[2];
            var character = characterFactory.CreateCharacter(faction, type, name);
            party.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemType = args[0];
            var item = itemFactory.CreateItem(itemType);
            itemPool.Push(item);

            return $"{itemType} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = FindCharacter(characterName);

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = itemPool.Pop();
            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];
            var character = FindCharacter(characterName); ;

            var item = AssureItem(character, itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = FindCharacter(giverName);

            var receiver = FindCharacter(receiverName);

            var item = AssureItem(giver, itemName);
            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = FindCharacter(giverName);
            var receiver = FindCharacter(receiverName);

            var item = AssureItem(giver, itemName);
            receiver.ReceiveItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var result = new StringBuilder();
            var orderdParty = party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health);
            foreach (var character in orderdParty)
            {
                result.AppendLine(character.ToString());
            }

            return result.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = FindCharacter(attackerName);
            if (!(attacker is IAttackable))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            var receiver = FindCharacter(receiverName);
            (attacker as Warrior).Attack(receiver);

            var result = new StringBuilder();
            result.Append($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! ");
            result.AppendLine($"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                result.AppendLine($"{receiver.Name} is dead!");
            }

            return result.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = FindCharacter(healerName);
            healer.DeterminIfAlive();
            var receiver = FindCharacter(healingReceiverName);
            receiver.DeterminIfAlive();

            if (!(healer is IHealable healingCharacter))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            healingCharacter.Heal(receiver);

            var result = new StringBuilder();
            result.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            return result.ToString().Trim();
        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = party.Where(c => c.IsAlive).ToList();
            var result = new StringBuilder();
            foreach (var character in aliveCharacters)
            {
                var healthBeforeRest = character.Health;
                character.Rest();
                result.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (aliveCharacters.Count <= 1)
            {
                lastSurvivorRounds++;
            }

            return result.ToString().Trim();
        }

        //Check if it works with lasruvi... =2;
        public bool IsGameOver()
        {
            var oneOrZeroSurvivorsLeft = party.Count(c => c.IsAlive) <= 1;
            var lastSurviverSurvivedTooLong = lastSurvivorRounds > 1;

            return oneOrZeroSurvivorsLeft && lastSurviverSurvivedTooLong;
        }

        private Character FindCharacter(string characterName)
        {
            var character = party.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }

        private Item AssureItem(Character character, string itemName)
        {
            var item = character.Bag.GetItem(itemName);

            return item;
        }
    }
}
