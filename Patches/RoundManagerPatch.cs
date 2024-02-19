using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RedPill.Patches
{
    [HarmonyPatch(typeof(RoundManager))]
    internal class RoundManagerPatch
    {
        [HarmonyPatch(nameof(RoundManager.FinishGeneratingLevel))]
        [HarmonyPostfix]
        static void ListAllEnemies()
        {
            ModDebug.LogInfo("List of enemies on this level");
            foreach (SpawnableEnemyWithRarity e in RoundManager.Instance.currentLevel.Enemies)
            {
                ModDebug.LogInfo($"(Rarity: {e.rarity}) {e.enemyType.name}");
            }

            ModDebug.LogInfo("List of enemies found from FindObjects");
            foreach (EnemyType e in Resources.FindObjectsOfTypeAll(typeof(EnemyType)))
            {
                //SpawnableEnemyWithRarity spawnable = new SpawnableEnemyWithRarity();
                //spawnable.enemyType = e;
                //ModDebug.LogInfo($" - {spawnable.enemyType.name}");

                ModDebug.LogInfo($" - {e.name}");
            }
        }
    }
}
