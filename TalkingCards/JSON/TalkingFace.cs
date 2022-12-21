using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DiskCardGame;
using TalkingCardAPI.TalkingCards.Animation;
using TalkingCardAPI.TalkingCards.Create;
using TalkingCardAPI.TalkingCards.Helpers;

namespace TalkingCardAPI.TalkingCards.JSON;

[Serializable]
public class TalkingData
{
    public string cardName { get; set; }
    public string faceSprite { get; set; }
    public FaceImagePath? eyeSprites { get; set; }
    public FaceImagePath? mouthSprites { get; set; }
    public string? emissionSprite { get; set; }
    public FaceInfo? faceInfo { get; set; }
    public DialogueEventStrings[] dialogueEvents { get; set; }

    public TalkingData(string cardName, string faceSprite, FaceImagePath? eyeSprites = null, FaceImagePath? mouthSprites = null, string? emissionSprites = null, FaceInfo? faceInfo = null, DialogueEventStrings[]? dialogueEvents = null)
    {
        this.cardName = cardName;
        this.faceSprite = faceSprite;
        this.eyeSprites = eyeSprites;
        this.mouthSprites = mouthSprites;
        this.emissionSprite = emissionSprites;
        this.faceInfo = faceInfo;
        this.dialogueEvents = dialogueEvents ?? new DialogueEventStrings[0];
    }

    public static Sprite EmptyCardPortrait => GeneratePortrait.EmptyCardPortrait ?? new();

    public List<EmotionData> GetEmotion() => new()
    {
        new(Emotion.Neutral,
            AssetHelpers.MakeSprite(faceSprite) ?? EmptyCardPortrait,
            eyeSprites?.GetSprites() ?? (EmptyCardPortrait, EmptyCardPortrait),
            mouthSprites?.GetSprites() ?? (EmptyCardPortrait, EmptyCardPortrait),
            AssetHelpers.MakeSprite(emissionSprite) ?? EmptyCardPortrait)
    };

    public FaceData GetFaceData() => new(cardName, GetEmotion(), faceInfo);
    public List<DialogueEvent?> MakeDialogueEvents()
        => dialogueEvents.Select(x => x?.CreateEvent(cardName)).ToList();
}

[Serializable]
public class FaceImagePath
{
    public string? open { get; set; }
    public string? closed { get; set; }

    public FaceImagePath(string open, string? closed)
    {
        this.open = open;
        this.closed = closed;
    }

    public (Sprite open, Sprite closed) GetSprites()
    {
        Sprite open = AssetHelpers.MakeSprite(this.open) ?? new Sprite();
        Sprite? closed = AssetHelpers.MakeSprite(this.closed);
        return (open, closed ?? open);
    }

    public static implicit operator FaceImagePath((string open, string closed) x)
        => new FaceImagePath(x.open, x.closed);
}