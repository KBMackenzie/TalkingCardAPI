using DiskCardGame;
using HarmonyLib;
using InscryptionAPI.Card;
using System.Collections.Generic;
using System.Linq;
using TalkingCardAPI.TalkingCards.Animation;
using UnityEngine;

#pragma warning disable Publicizer001

namespace TalkingCardAPI.TalkingCards.Create;

internal static class TalkingCardCreator
{
    public static List<string> AllDialogueAdded => DialogueDummy.AllDialogueAdded;

    public static Dictionary<string, GameObject> Reindeer = new();

    #region AnimatedPortrait
    public static FaceInfo BasicInfo()
    {
        FaceInfo faceInfo = new FaceInfo(
                GeneratePortrait.BlinkRate,
                GeneratePortrait.VoiceId,
                GeneratePortrait.VoicePitch
            );
        return faceInfo;
    }

    public static void New(FaceData faceData)
    {
        if (Reindeer.ContainsKey(faceData.CardName))
        {
            Plugin.LogError("A face was already added for that card!");
            return;
        }

        GameObject portrait = GeneratePortrait.New();
        CharacterFace face = portrait.GetComponent<CharacterFace>();
        face.emotionSprites = faceData.Emotions.Select(x => x.MakeEmotion()).ToList();

        FaceInfo faceInfo = faceData.FaceInfo ?? BasicInfo();

        face.eyes.blinkRate = faceInfo.GetBlinkRate();
        face.voiceSoundId = faceInfo.GetVoiceId();
        face.voiceSoundPitch = faceInfo.GetVoicePitch();

        CardInfo? card = CardLoader.GetCardByName(faceData.CardName);
        if (card == null) return;

        Reindeer.Add(faceData.CardName, portrait);
        card.AddAppearances(CardAppearanceBehaviour.Appearance.AnimatedPortrait);
        card.AddSpecialAbilities(GeneratePortrait.DialogueAbility);
    }
    #endregion

    #region Dialogue
    public static void AddToDialogueCache(string? id)
    {
        if (id == null) return;
        AllDialogueAdded.Add(id);
    }
    #endregion

    [HarmonyPatch]
    private static class Patches
    {
        [HarmonyPatch(typeof(CardInfo), nameof(CardInfo.AnimatedPortrait), MethodType.Getter)]
        [HarmonyPostfix]
        private static void GetFace(CardInfo __instance, ref GameObject __result)
        {
            if (!Reindeer.ContainsKey(__instance.name)) return;

            __instance.animatedPortrait = Reindeer[__instance.name];
            __result = Reindeer[__instance.name];
        }
    }
}