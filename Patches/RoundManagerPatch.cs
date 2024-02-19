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
        static void AddRedPillToEnemiesList()
        {
            EnemyType redPillEnemyType = null;
            foreach (EnemyType e in Resources.FindObjectsOfTypeAll(typeof(EnemyType)))
            {
                if (e.name == "RedPillEnemyType")
                {
                    ModDebug.LogInfo($"Found {e.name}! Object: {e}");
                    redPillEnemyType = e;
                }
            }

            SpawnableEnemyWithRarity redPill = new SpawnableEnemyWithRarity();
            if ( redPillEnemyType != null )
            {
                redPill.enemyType = redPillEnemyType;
                redPill.rarity = 100;
                RoundManager.Instance.currentLevel.Enemies = new List<SpawnableEnemyWithRarity>() { redPill };
            }

            #region list all enemies
            ModDebug.LogInfo("List of enemies on this level");
            foreach (SpawnableEnemyWithRarity e in RoundManager.Instance.currentLevel.Enemies)
            {
                ModDebug.LogInfo($"(Rarity: {e.rarity}) {e.enemyType.name}");
            }

            //ModDebug.LogInfo("List of enemies found from FindObjects");
            #endregion
        }
    }
}
