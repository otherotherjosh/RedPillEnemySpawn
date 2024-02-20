using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedPill.Patches
{
    [HarmonyPatch(typeof(TestEnemy))]
    internal class TestEnemyPatch
    {
        [HarmonyPatch(nameof(TestEnemy.Update))]
        [HarmonyPrefix]
        static void UpdateSpeed(ref TestEnemy __instance)
        {
            if (!ConfigController.useOriginalAI.Value) { return; }

            __instance.agent.speed = 10f;
            if (__instance.closestPlayerDist < 12)
            {
                __instance.agent.speed /= 2f;
            }
            if (__instance.closestPlayerDist < 8)
            {
                __instance.agent.speed /= 2f;
            }
            if (__instance.closestPlayerDist < 5)
            {
                __instance.agent.speed /= 1.5f;
            }
        }
    }
}
