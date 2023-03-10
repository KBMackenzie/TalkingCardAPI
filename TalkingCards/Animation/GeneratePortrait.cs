using DiskCardGame;
using InscryptionAPI.Card;
using System.Collections.Generic;
using UnityEngine;
using TalkingCardAPI.TalkingCards.Helpers;

#pragma warning disable Publicizer001

namespace TalkingCardAPI.TalkingCards.Animation;

internal static class GeneratePortrait
{
    public static AssetBundle? PortraitBundle;
    private static GameObject? FacePrefab;
    private static Transform? APIPortraits;

    #region FaceInfoDefault
    public const string VoiceId = "female1_voice";
    public const float BlinkRate = 1.5f;
    public const float VoicePitch = 1f;
    #endregion

    public static SpecialTriggeredAbility DialogueDummy;

    #region Sprites
    internal static readonly Sprite EmptyPortrait
        = AssetHelpers.MakeSprite(AssetHelpers.EmptyAndTransparent());
    
    internal static readonly (Sprite, Sprite) EmptyPortraitTuple
        = (EmptyPortrait, EmptyPortrait);
    #endregion

    public static void InitTalkingCards()
    {
        LoadPrefab();
        Portrait();
        AddAbility();
    }

#pragma warning disable CS8600
    public static GameObject New()
    {
        GameObject portrait = GameObject.Instantiate(FacePrefab);
        GameObject.DontDestroyOnLoad(portrait);
        portrait!.transform.SetParent(APIPortraits);
        return portrait;
    }
#pragma warning restore CS8600

    #region InitGenericPortrait
    private static void LoadPrefab()
    {
        PortraitBundle = AssetBundle.LoadFromMemory(Properties.Resources.TalkingCardGenericPrefab);
    }

    private static void AddAbility()
    {
        DialogueDummy = SpecialTriggeredAbilityManager.Add(
                Plugin.PluginGuid,
                "TalkingCardAPI_",
                typeof(DialogueDummy)
            ).Id;
    }

    private static void Portrait()
    {
        FacePrefab = PortraitBundle!.LoadAsset<GameObject>("TalkingCardGenericPrefab");

        Transform Anim = FacePrefab.transform.Find("Anim");
        Transform Body = Anim.transform.Find("Body");
        Transform Eyes = Body.Find("Eyes");
        Transform Mouth = Body.Find("Mouth");

        CharacterFace face = FacePrefab.AddComponent<CharacterFace>();
        face.anim = Anim.gameObject.GetComponent<Animator>();
        face.eyes = Eyes.gameObject.AddComponent<CharacterEyes>();
        face.mouth = Mouth.gameObject.AddComponent<CharacterMouth>();
        face.face = Body.gameObject.GetComponent<SpriteRenderer>();

        face.face.sprite = EmptyPortrait;
        Eyes.GetComponent<SpriteRenderer>().sprite = EmptyPortrait;
        Mouth.GetComponent<SpriteRenderer>().sprite = EmptyPortrait;

        face.emotionSprites = new List<CharacterFace.EmotionSprites>
         {
            new CharacterFace.EmotionSprites
            {
                emotion = Emotion.Neutral,
                face = EmptyPortrait,
                eyesOpen = EmptyPortrait,
                mouthClosed = EmptyPortrait,
                eyesClosed = EmptyPortrait,
                eyesOpenEmission = EmptyPortrait,
                mouthOpen = EmptyPortrait,
            }};

        face.eyes.blinkRate = BlinkRate;
        face.voiceSoundId = VoiceId;
        face.voiceSoundPitch = VoicePitch;

        int offscreen = LayerMask.NameToLayer("CardOffscreen");
        foreach (Transform t in FacePrefab.GetComponentsInChildren<Transform>())
        {
            t.gameObject.layer = offscreen;
        }

        FacePrefab.layer = offscreen;
        
        face.eyes.emissionRenderer = face.eyes.transform.Find("Emission").GetComponent<SpriteRenderer>();
        face.eyes.emissionRenderer.gameObject.layer = LayerMask.NameToLayer("CardOffscreenEmission");
        face.eyes.emissionRenderer.sprite = EmptyPortrait;

        GameObject apiPortraits = new GameObject("API_Portraits");
        GameObject.DontDestroyOnLoad(apiPortraits);
        APIPortraits = apiPortraits.transform;
    }
    #endregion
}
