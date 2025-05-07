using BepInEx;
using BepInEx.Logging;
using AirFilterWarning.Patches;

namespace AirFilterWarning
{
    [
        BepInPlugin("ZGFueDkx.AirFilterWarning", "AirFilterWarning", "1.0.0"),
        BepInDependency("com.SPT.core", "3.11"),
    ]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource LogSource;
        private void Awake()
        {
            LogSource = Logger;

            new MainMenuShowScreenPatch().Enable();

            LogSource.LogInfo($"AirFilterWarning by ZGFueDkx version {Info.Metadata.Version} started");
        }
    }
}
