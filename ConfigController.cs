using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedPill
{
    internal static class ConfigController
    {
        internal static ConfigEntry<int> spawnRarityGeneral;
        internal static ConfigEntry<int> spawnCount;
        internal static ConfigEntry<bool> spawnRarityFromDifficulty;

        internal static ConfigEntry<bool> useOriginalAI;
        internal static ConfigEntry<float> agentSpeedBase;
        internal static ConfigEntry<float> agentSpeedSlowDownAmount;

        internal static void Initialize(ConfigFile configFile)
        {
            #region spawn rules
            spawnRarityGeneral = configFile.Bind(
                "Spawning",
                "Rarity",
                1,
                "Weighted probability of spawning on any moon\n" +
                "For reference, the most common enemy on a moon is usually set to around 50-60\n" +
                "and the least common (like a Nutcracker on Experimentation) is often 1"
            );

            spawnCount = configFile.Bind(
                "Spawning",
                "Max count",
                1,
                "How many Red Pills can potentially spawn in one day"
            );

            //spawnRarityFromDifficulty = configFile.Bind(
            //    "Spawn Rarity",
            //    "Get rarity from hazard level",
            //    false,
            //    "Use different spawn probabilities for different hazard levels"
            //);
            #endregion

            #region AI rules
            useOriginalAI = configFile.Bind(
                "AI",
                "Use custom AI",
                true,
                "(Overrides all other AI options)\n" +
                "Enable custom AI behaviors, otherwise use vanilla test enemy AI"
            );

            agentSpeedBase = configFile.Bind(
                "AI",
                "Base movement speed",
                10f,
                "How fast the Red Pill moves before being slowed down by player proximity"
            );

            agentSpeedSlowDownAmount = configFile.Bind(
                "AI",
                "Proximity speed effect",
                2.5f,
                "How much the Red Pill slows down when it gets close to a player\n" +
                "The movement speed is divided by this value when the Red Pill is extremely close"
            );
            #endregion
        }
    }
}
