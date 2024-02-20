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

        private ConfigEntry<bool> useOriginalAI;

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
            #region spawn rules
            spawnRarityGeneral = configFile.Bind(
                "Spawn Rarity",
                "General rarity",
                1,
                "Weighted probability of spawning on any moon"
            );

            spawnRarityFromDifficulty = configFile.Bind(
                "Spawn Rarity",
                "General rarity",
                true,
                "(Overrides general rarity) Use different spawn probabilities for different hazard levels"
            );
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
