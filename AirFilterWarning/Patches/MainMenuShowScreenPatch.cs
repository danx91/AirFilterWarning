using Comfort.Common;
using EFT.Hideout;
using EFT.UI;
using HarmonyLib;
using SPT.Reflection.Patching;
using System;
using System.Linq;
using System.Reflection;

namespace AirFilterWarning.Patches
{
    class MainMenuShowScreenPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(MainMenuControllerClass), nameof(MainMenuControllerClass.ShowScreen));
        }

        [PatchPrefix]
        static bool Prefix(MainMenuControllerClass __instance, EMenuType screen)
        {
            if (screen == EMenuType.Exit)
            {
                string text = "UI/leave_game_confirmation_text".Localized(null);

                HideoutClass? hideout = Singleton<HideoutClass>.Instantiated ? Singleton<HideoutClass>.Instance : null;
                if (hideout != null)
                {
                    if (hideout.EnergyController.IsEnergyGenerationOn)
                    {
                        text = text + "\n<color=\"red\">" + "UI/Generator is working".Localized(null) + "</color>";
                    }

                    AreaData airFilteringUnit = hideout.AreaDatas.FirstOrDefault(a => a.Template.Type == EFT.EAreaType.AirFilteringUnit);
                    if (airFilteringUnit != null && airFilteringUnit.HasActiveProduction)
                    {
                        text = text + "\n<color=\"red\">You left the air filter working!</color>";
                    }
                }

                ItemUiContext.Instance.ShowMessageWindow(text, new Action(__instance.method_69), new Action(MainMenuControllerClass.Class1516.class1516_0.method_2), "UI/leave_game_confirmation_caption".Localized(null), 0f, false, TMPro.TextAlignmentOptions.Center);
                return false;
            }

            return true;
        }
    }
}
