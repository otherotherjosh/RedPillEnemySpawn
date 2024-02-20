using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedPill
{
    internal static class ConfigController
    {
        private static ConfigEntry<int> spawnRarityGeneral;
        private static ConfigEntry<bool> spawnRarityFromDifficulty;

        private static ConfigEntry<bool> useOriginalAI;

        //internal ConfigEntry<int> Rarity
        //{
        //    get => rarity;
        //    set
        //    {
        //        rarity.Value = Math.Clamp(value.Value, 0, 100);
        //    }
        //}

        internal static void Initialize(ConfigFile configFile)
        {
            #region spawn rules
            spawnRarityGeneral = configFile.Bind(
                "Spawn Rarity",
                "General rarity",
                1,
                "Weighted probability of spawning on any moon"
            );

            //spawnRarityFromDifficulty = configFile.Bind(
            //    "Spawn Rarity",
            //    "Get rarity from hazard level",
            //    false,
            //    "(Overrides general rarity) Use different spawn probabilities for different hazard levels"
            //);
            #endregion

            #region AI rules
            useOriginalAI = configFile.Bind(
                "AI",
                "Use custom AI",
                true,
                "(Overrides all other AI options) Enable custom AI behaviors, otherwise use vanilla test enemy AI"
            );
            #endregion
        }
    }
}
