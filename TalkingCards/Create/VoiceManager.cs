using HarmonyLib;
using InscryptionAPI.Sound;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TalkingCardAPI.TalkingCards.Helpers;
using UnityEngine;

namespace TalkingCardAPI.TalkingCards.Create;

[HarmonyPatch]
internal static class VoiceManager
{
    private static readonly List<AudioClip> Voices = new();

    public static void Add(string soundPath, string? soundId)
    {
        AudioClip voice = SoundManager.LoadAudioClip(soundPath);
        voice.name = soundId ?? soundPath;
        Voices.Add(voice);
    }

    [HarmonyPatch(typeof(AudioController), nameof(AudioController.GetAudioClip))]
    [HarmonyPrefix]
    private static void AddVoiceIds(ref List<AudioClip> ___SFX)
    {
        foreach(AudioClip voice in Voices)
        {
            if (!___SFX.Contains(voice))
            {
                ___SFX.Add(voice);
            }
        }
    }
}
