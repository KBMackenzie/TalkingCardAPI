﻿using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TalkingCardAPI.TalkingCards.Helpers;
using UnityEngine;

namespace TalkingCardAPI.TalkingCards.Create;

[HarmonyPatch]
internal static class ColorManager
{
    private static readonly Dictionary<string, Color> ColorsCache = new();

    private static readonly Regex ColorRegex = new(@"^#?([0-9a-fA-F]{6})$");

    [HarmonyPatch(typeof(DialogueParser), nameof(DialogueParser.GetColorFromCode))]
    [HarmonyPostfix]
    private static void GetCustomColor(string code, ref Color __result)
    {
        string hex = DialogueParser.GetStringValue(code, "c");
        
        if (!ColorRegex.IsMatch(hex)) return;

        if (ColorsCache.ContainsKey(hex))
        {
            __result = ColorsCache[hex];
            return;
        }

        Color color = AssetHelpers.HexToColor(hex);
        ColorsCache.Add(hex, color);
        __result = color;
    }
}
