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
        static void UpdateWithSpeed(ref TestEnemy __instance)
        {
            __instance.agent.speed = 2f;
        }
    }
}
