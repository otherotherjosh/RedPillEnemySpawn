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
            AnimationCurve probabilityCurve = null;
            
            #region list all enemies
            ModDebug.LogInfo("List of enemies on this level");
            foreach (SpawnableEnemyWithRarity e in RoundManager.Instance.currentLevel.Enemies)
            {
                ModDebug.LogInfo($"(Rarity: {e.rarity}) {e.enemyType.name}");
            }
            #endregion

            foreach (EnemyType e in Resources.FindObjectsOfTypeAll(typeof(EnemyType)))
            {
                if (e.name == "BaboonHawk")
                {
                    ModDebug.LogInfo($"Found {e.name}! Stealing probability curve...");
                    probabilityCurve = e.probabilityCurve;

                }
                if (e.name == "RedPillEnemyType")
                {
                    ModDebug.LogInfo($"Found {e.name}! Object: {e}");
                    e.MaxCount = 5;
                    redPillEnemyType = e;
                }
                ModDebug.LogInfo($"{e.name}, max: {e.MaxCount}, curve: {e.probabilityCurve.length}, spawningDisabled: {e.spawningDisabled}\n" +
                    $"power: {e.PowerLevel}");
            }

            SpawnableEnemyWithRarity redPill = new SpawnableEnemyWithRarity();
            if ( redPillEnemyType != null )
            {
                redPill.enemyType = redPillEnemyType;
                redPill.enemyType.probabilityCurve = probabilityCurve;
                redPill.rarity = 58;
                RoundManager.Instance.currentLevel.Enemies = new List<SpawnableEnemyWithRarity>() { redPill };
            }

            #region list all enemies
            ModDebug.LogInfo("List of enemies on this level");
            foreach (SpawnableEnemyWithRarity e in RoundManager.Instance.currentLevel.Enemies)
            {
                ModDebug.LogInfo($"(Rarity: {e.rarity}) {e.enemyType.name}");
            }
            #endregion
        }
    }
}
