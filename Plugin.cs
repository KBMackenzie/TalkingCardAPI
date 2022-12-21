using BepInEx;
using System.IO;
using HarmonyLib;
using System;
using InscryptionAPI.Ascension;
using BepInEx.Logging;
using System.Collections.Generic;
using UnityEngine;
using TalkingCardAPI.TalkingCards.Animation;
using TalkingCardAPI.TalkingCards.JSON;

namespace TalkingCardAPI;

// Plugin base:
[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("MADH.inscryption.JSONLoader", BepInDependency.DependencyFlags.SoftDependency)]
public class Plugin : BaseUnityPlugin
{   
    public const string PluginGuid = "kel.inscryption.talkingcardapi";
    public const string PluginName = "TalkingCardAPI";
    public const string PluginVersion = "1.0.0";

    internal static Plugin? Instance;

    private void Awake()
    {
        Instance = this; // Make log source.

        Harmony harmony = new Harmony("kel.harmony.talkingcardapi");
        harmony.PatchAll();

        GeneratePortrait.InitTalkingCards();
        LoadJSON.LoadJSONCards();
    }

    internal static void LogInfo(string message) => Instance?.Logger.LogInfo(message);
    internal static void LogError(string message) => Instance?.Logger.LogError(message);
}
