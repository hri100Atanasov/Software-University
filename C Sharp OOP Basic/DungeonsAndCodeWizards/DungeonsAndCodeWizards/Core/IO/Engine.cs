using DungeonsAndCodeWizards.Core.IO.Contracts;
using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Core.IO
{
    public class Engine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly DungeonMaster dungeonMaster;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            isRunning = true;
            while (isRunning)
            {
                var command = reader.ReadLine();

                try
                {
                    ReadCommand(command);
                }
                catch (ArgumentException argE)
                {
                    writer.Write($"Parameter Error: {argE.Message}");
                }
                catch (InvalidOperationException invOpE)
                {
                    writer.Write($"Invalid Operation: {invOpE.Message}");
                }

                if (dungeonMaster.IsGameOver() || isRunning == false)
                {
                    writer.Write("Final stats:");
                    writer.Write(dungeonMaster.GetStats());
                    isRunning = false;
                }
            }
        }

        private void ReadCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                isRunning = false;
                return;
            }

            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();
            var output = string.Empty;

            switch (commandName)
            {
                case "JoinParty":
                    output = dungeonMaster.JoinParty(args);
                    break;
                case "AddItemToPool":
                    output = dungeonMaster.AddItemToPool(args);
                    break;
                case "PickUpItem":
                    output = dungeonMaster.PickUpItem(args);
                    break;
                case "UseItem":
                    output = dungeonMaster.UseItem(args);
                    break;
                case "UseItemOn":
                    output = dungeonMaster.UseItemOn(args);
                    break;
                case "GiveCharacterItem":
                    output = dungeonMaster.GiveCharacterItem(args);
                    break;
                case "GetStats":
                    output = dungeonMaster.GetStats();
                    break;
                case "Attack":
                    output = dungeonMaster.Attack(args);
                    break;
                case "Heal":
                    output = dungeonMaster.Heal(args);
                    break;
                case "EndTurn":
                    output = dungeonMaster.EndTurn(args);
                    break;
            }

            if (output != string.Empty)
            {
                writer.Write(output);
            }
        }
    }
}
