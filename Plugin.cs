using BepInEx;
using HarmonyLib;

namespace RedPill
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PLUGIN_GUID = "NBFBs.RedPill";
        private const string PLUGIN_NAME = "Red Pill Enemy Spawn";
        private const string PLUGIN_VERSION = "0.1.0";

        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PLUGIN_GUID} (\"{PLUGIN_NAME}\") is loaded!");
        }
    }
}
