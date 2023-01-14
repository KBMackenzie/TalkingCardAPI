using BepInEx;
using HarmonyLib;
using TalkingCardAPI.TalkingCards.Animation;
using TalkingCardAPI.TalkingCards.JSON;

namespace TalkingCardAPI;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("MADH.inscryption.JSONLoader", BepInDependency.DependencyFlags.SoftDependency)]
public class Plugin : BaseUnityPlugin
{   
    public const string PluginGuid = "kel.inscryption.talkingcardapi";
    public const string PluginName = "TalkingCardAPI";
    public const string PluginVersion = "0.2.0";

    internal static Plugin? Instance;

    private void Awake()
    {
        Instance = this;

        Harmony harmony = new Harmony("kel.harmony.talkingcardapi");
        harmony.PatchAll();

        try
        {
            GeneratePortrait.InitTalkingCards();
        }
        catch (System.Exception)
        {
            Logger.LogWarning("Exception caught: This probably just means you're using a newer version of the API, in which case, you don't need to use this mod.");
            Logger.LogWarning("The latest version of the API already includes support for Talking Cards! You can use JSONLoader instead of this mod now!");
            return;
        }

        LoadJSON.LoadJSONCards();
    }

    internal static void LogInfo(string message) => Instance?.Logger.LogInfo(message);
    internal static void LogError(string message) => Instance?.Logger.LogError(message);
}
