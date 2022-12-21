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

    public const string VoiceId = "female1_voice";
    public const float BlinkRate = 1.5f;
    public const float VoicePitch = 1f;

    public static SpecialTriggeredAbility DialogueAbility;
    public static Sprite? EmptyCardPortrait;

    public static void InitTalkingCards()
    {
        LoadPrefab();
        Portrait();
        AddAbility();
    }

#pragma warning disable CS8600
#pragma warning disable CS8603
    public static GameObject New()
    {
        GameObject portrait = GameObject.Instantiate(FacePrefab);
        GameObject.DontDestroyOnLoad(portrait);
        //portrait!.transform.SetParent(APIPortraits);
        return portrait;
    }
#pragma warning restore CS8600
#pragma warning restore CS8603

    #region InitGenericPortrait
    private static void LoadPrefab()
    {
        PortraitBundle = AssetBundle.LoadFromMemory(Properties.Resources.TalkingCardGenericPrefab);
    }

    private static void AddAbility()
    {
        DialogueAbility = SpecialTriggeredAbilityManager.Add(
                Plugin.PluginGuid,
                "CustomStoatTalker",
                typeof(DialogueDummy)
            ).Id;

        //DialogueDummy.DummyEvent();
    }

    private static void Portrait()
    {
        FacePrefab = PortraitBundle!.LoadAsset<GameObject>("TalkingCardGenericPrefab");

        /* No need for a global static variable if you don't destroy on load! ><
         * I can use this to allow for unique card customizations from one prefab! <3 */

        Transform Anim = FacePrefab.transform.Find("Anim");
        Transform Body = Anim.transform.Find("Body");
        Transform Eyes = Body.Find("Eyes");
        Transform Mouth = Body.Find("Mouth");

        CharacterFace face = FacePrefab.AddComponent<CharacterFace>();
        face.anim = Anim.gameObject.GetComponent<Animator>();
        face.eyes = Eyes.gameObject.AddComponent<CharacterEyes>();
        face.mouth = Mouth.gameObject.AddComponent<CharacterMouth>();
        face.face = Body.gameObject.GetComponent<SpriteRenderer>();

        EmptyCardPortrait = AssetHelpers.MakeSprite(Properties.Resources.EmptyCardPortrait);

        face.face.sprite = EmptyCardPortrait;
        Eyes.GetComponent<SpriteRenderer>().sprite = EmptyCardPortrait;
        Mouth.GetComponent<SpriteRenderer>().sprite = EmptyCardPortrait;

        face.emotionSprites = new List<CharacterFace.EmotionSprites>
         {
            new CharacterFace.EmotionSprites
            {
                emotion = Emotion.Neutral,
                face = EmptyCardPortrait,
                eyesOpen = EmptyCardPortrait,
                mouthClosed = EmptyCardPortrait,
                eyesClosed = EmptyCardPortrait,
                eyesOpenEmission = EmptyCardPortrait,
                mouthOpen = EmptyCardPortrait,
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
        face.eyes.emissionRenderer.sprite = EmptyCardPortrait;

        GameObject apiPortraits = new GameObject("API_Portraits");
        GameObject.DontDestroyOnLoad(apiPortraits);
        APIPortraits = apiPortraits.transform;

        //CardInfo stoat = CardManager.New("kel", "PossumTalking", "Stoat", 1, 3);
        //stoat.animatedPortrait = FacePrefab;
        //stoat.AddAppearances(CardAppearanceBehaviour.Appearance.AnimatedPortrait);
        //stoat.AddSpecialAbilities(ability);
    }
    #endregion
}