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

        GeneratePortrait.InitTalkingCards();
        LoadJSON.LoadJSONCards();
    }

    internal static void LogInfo(string message) => Instance?.Logger.LogInfo(message);
    internal static void LogError(string message) => Instance?.Logger.LogError(message);
}
