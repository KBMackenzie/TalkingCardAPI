﻿using DiskCardGame;
using Newtonsoft.Json;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TalkingCardAPI.TalkingCards.Animation;
using UnityEngine;

namespace TalkingCardAPI.TalkingCards.Create;

public class FaceData
{
    public string CardName { get; }
    public List<EmotionData> Emotions { get; }
    public EmotionData Neutral => Emotions.Find(x => x.Emotion == Emotion.Neutral);
    public FaceInfo? FaceInfo { get; set; }

    public FaceData(string cardName, List<EmotionData> emotions, FaceInfo? faceInfo)
    {
        CardName = cardName;
        Emotions = emotions;
        FaceInfo = faceInfo;
    }
}

[Serializable]
public class FaceInfo
{
    internal static readonly string[] ValidVoiceIds = new string[]
    {
        "female1_voice",
        "kobold_voice",
        "cat_voice"
    };

    /* Yes, I know these names should be capitalized.
     * However... JSON. */

    public float blinkRate { get; set; }
    public string? voiceId { get; set; }
    public float voiceSoundPitch { get; set; }

    public FaceInfo(float blinkRate, string? voiceID, float voiceSoundPitch)
    {
        this.blinkRate = blinkRate;
        voiceId = voiceID;
        this.voiceSoundPitch = voiceSoundPitch;
    }

    public float GetBlinkRate() => Mathf.Clamp(blinkRate, 0.1f, 10f);
    public float GetVoicePitch() => Mathf.Clamp(voiceSoundPitch, 0.1f, 10f);

    public string GetVoiceId() // Ensure VoiceId is not null and is in list.
        => voiceId == null
        ? ValidVoiceIds.First()
        : 
            ValidVoiceIds.Contains(voiceId)
            ? voiceId
            : ValidVoiceIds.First()
        ;
}

public class EmotionData
{
    public Emotion Emotion { get; }
    public Sprite Face { get; }
    public FaceAnim Eyes { get; }
    public FaceAnim Mouth { get; }
    public Sprite Emission { get; }
    public EmotionData(Emotion emotion, Sprite face, FaceAnim eyes, FaceAnim mouth, Sprite emission)
    {
        Emotion = emotion;
        Face = face;
        Eyes = eyes;
        Mouth = mouth;
        Emission = emission;
    }

    public static implicit operator CharacterFace.EmotionSprites(EmotionData x) => new()
    {
        emotion = x.Emotion,
        face = x.Face,

        // Eyes
        eyesOpen = x.Eyes.Open,
        eyesClosed = x.Eyes.Closed,

        // Mouth
        mouthOpen = x.Mouth.Open,
        mouthClosed = x.Mouth.Closed,

        // Emission
        eyesOpenEmission = x.Emission,
    };

    public static Sprite EmptyPortrait => GeneratePortrait.EmptyCardPortrait ?? new Sprite();

    public static implicit operator EmotionData((Emotion emotion, Sprite sprite) x)
        => new(x.emotion, x.sprite, EmptyPortrait, EmptyPortrait, EmptyPortrait);
}

public class FaceAnim
{
    // These sprites will *never* be null.
    // They can, however, be just empty sprites.
    public Sprite Open { get; }
    public Sprite Closed { get; }

    public FaceAnim(Sprite open, Sprite closed)
    {
        Open = open;
        Closed = closed;
    }

    public static implicit operator Sprite(FaceAnim x)
        => x.Closed;

    public static implicit operator FaceAnim(Sprite s)
        => new FaceAnim(s, s);

    public static implicit operator FaceAnim((Sprite open, Sprite closed) x)
        => new FaceAnim(x.open, x.closed);
}