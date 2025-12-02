using BepInEx;
using BepInEx.Logging;
using AirFilterWarning.Patches;

namespace AirFilterWarning
{
    [
        BepInPlugin("com.zgfuedkx.airfilterwarning", "AirFilterWarning", "1.1.0"),
        BepInDependency("com.SPT.core", "4.0"),
    ]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource? LogSource;
        private void Awake()
        {
            LogSource = Logger;

            new MainMenuShowScreenPatch().Enable();

            LogSource.LogInfo($"AirFilterWarning by ZGFueDkx version {Info.Metadata.Version} started");
        }
    }
}
