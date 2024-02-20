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
        [HarmonyPatch(nameof(TestEnemy.Update))]
        [HarmonyPrefix]
        static void UpdateSpeed(ref TestEnemy __instance)
        {
            if (!ConfigController.useOriginalAI.Value) { return; }

            float proximityEffect = Mathf.InverseLerp(15f, 3f, __instance.closestPlayerDist) * ConfigController.agentSpeedSlowDownAmount.Value;
            __instance.agent.speed = ConfigController.agentSpeedBase.Value;
            __instance.agent.speed /= Mathf.Clamp(proximityEffect, 1f, 999f);
        }
    }
}
