using BepInEx;
using System.IO;
using HarmonyLib;
using System;
using InscryptionAPI.Ascension;
using BepInEx.Logging;
using System.Collections.Generic;
using UnityEngine;

namespace TalkingCardAPI
{
    // Plugin base:
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {   
        public const string PluginGuid = "kel.inscryption.talkingcardapi";
        public const string PluginName = "TalkingCardAPI";
        public const string PluginVersion = "1.0.0.0";

        public static AssetBundle PossumBundle;

        internal static ManualLogSource myLogger; // Log source.
        private void Awake() {

            myLogger = Logger; // Make log source.

            Harmony harmony = new Harmony("kel.harmony.talkingcardapi");
            harmony.PatchAll();

            PossumBundle = AssetBundle.LoadFromMemory(Properties.Resources.PossumBundle);
            TalkingPossum.Init();
        }
    }
}
