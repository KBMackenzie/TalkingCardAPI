using DiskCardGame;
using HarmonyLib;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TalkingCardAPI.TalkingCards.Helpers;

namespace TalkingCardAPI.TalkingCards.Create;

[HarmonyPatch]
internal static class EmotionManager
{
    // An accurate list of the names.
    private static readonly string[] nameOfKeys = EnumHelpers.NameArray<Emotion>();

    // A forgiving, not case-sensitive array of names.
    private static readonly string[] namesToLower = EnumHelpers.NameArray<Emotion>(toLower: true);

    [HarmonyPatch(typeof(SequentialText), nameof(SequentialText.ConsumeCode))]
    [HarmonyPrefix]
    private static void CorrectEmotionNames(ref string code)
    {
        if (!code.StartsWith("[e")) return;
        string x = DialogueParser.GetStringValue(code, "e");

        if (nameOfKeys.Contains(x) || !namesToLower.Contains(x.ToLower())) return;
        code = code.FormatKey();
    }
}
