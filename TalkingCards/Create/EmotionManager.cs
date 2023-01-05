﻿using DiskCardGame;
using HarmonyLib;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using TalkingCardAPI.TalkingCards.Helpers;

namespace TalkingCardAPI.TalkingCards.Create;

[HarmonyPatch]
internal static class EmotionManager
{
    // An accurate list of the names.
    private static readonly string[] nameOfKeys = Enum.GetNames(typeof(Emotion));
    private static readonly Regex emotionRegex = new Regex(@"^\[e\:[a-zA-Z]*\]");

    [HarmonyPatch(typeof(SequentialText), nameof(SequentialText.ConsumeCode))]
    [HarmonyPrefix]
    private static void CorrectEmotionNames(ref string code)
    {
        if (!code.StartsWith("[e")) return;
        string x = DialogueParser.GetStringValue(code, "e");

        if (nameOfKeys.Contains(x) || int.TryParse(x, out _)) return;
        code = emotionRegex.Replace(code, $@"[e:{x.SentenceCase()}]");
    }
}
