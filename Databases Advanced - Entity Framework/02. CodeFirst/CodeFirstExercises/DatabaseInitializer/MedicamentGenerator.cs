﻿using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInitializer
{
    class MedicamentGenerator
    {
        internal static void InitialMedicamentSeed(HospitalContext context)
        {
            var medicamentNames = new string[]
            {
                "Biseptol",
                "Ciclobenzaprina",
                "Curam",
                "Diclofenaco",
                "Disflatyl",
                "Duvadilan",
                "Efedrin",
                "Flanax",
                "Fluimucil",
                "Navidoxine",
                "Nistatin",
                "Olfen",
                "Pentrexyl",
                "Primolut Nor",
                "Primperan",
                "Propoven",
                "Reglin",
                "Terramicina Oftalmica",
                "Ultran",
                "Viartril-S",
            };
            //var medicamentNames = File.ReadAllLines("<INSERT DIR HERE>");

            for (int i = 0; i < medicamentNames.Length; i++)
            {
                context.Medicaments.Add(new Medicament() { Name = medicamentNames[i] });
            }

            context.SaveChanges();
        }

        public static void Generate(string medicamentName, HospitalContext context)
        {
            context.Medicaments.Add(new Medicament() { Name = medicamentName });
        }
    }
}
