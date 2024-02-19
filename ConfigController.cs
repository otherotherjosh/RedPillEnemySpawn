using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedPill
{
    internal class ConfigController
    {
        private ConfigEntry<int> spawnRarityGeneral;
        private ConfigEntry<bool> spawnRarityFromDifficulty;

        //internal ConfigEntry<int> Rarity
        //{
        //    get => rarity;
        //    set
        //    {
        //        rarity.Value = Math.Clamp(value.Value, 0, 100);
        //    }
        //}

        public ConfigController(ConfigFile configFile)
        {
            spawnRarityGeneral = configFile.Bind(
                "Spawn Rarity",
                "General rarity",
                1,
                "Weighted probability of spawning on any moon"
            );

            spawnRarityFromDifficulty = configFile.Bind(
                "Spawn Rarity",
                "General rarity",
                false,
                "(Overrides general rarity) Use different spawn probabilities for different hazard levels"
            );
        }
    }
}
