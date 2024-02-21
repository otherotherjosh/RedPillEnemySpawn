using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RedPill.Patches
{
    [HarmonyPatch(typeof(TestEnemy))]
    internal class TestEnemyPatch
    {
        [HarmonyPatch(nameof(TestEnemy.Start))]
        [HarmonyPostfix]
        static void ChangeInstanceVars(ref TestEnemy __instance)
        {
            __instance.detectionRadius = ConfigController.playerDetectionRadius.Value;
        }

        [HarmonyPatch(nameof(TestEnemy.Update))]
        [HarmonyPrefix]
        static void UpdateSpeed(ref TestEnemy __instance)
        {
            if (!ConfigController.useOriginalAI.Value) { return; }

            float proximityEffect = Mathf.InverseLerp(15f, 3f, __instance.closestPlayerDist) * ConfigController.agentSpeedSlowDownAmount.Value;
            __instance.agent.speed = ConfigController.agentSpeedBase.Value;
            __instance.agent.speed /= Mathf.Clamp(proximityEffect, 1f, 999f);

#if DEBUG
            // maybe don't do this in a release build
            if (ConfigController.playerDetectionRadius.Value != __instance.detectionRadius)
            {
                __instance.detectionRadius = ConfigController.playerDetectionRadius.Value;
                ModDebug.LogInfo($"Changing detection radius to {__instance.detectionRadius}");
            }
#endif
        }
    }
}
