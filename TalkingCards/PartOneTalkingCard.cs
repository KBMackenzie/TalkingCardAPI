using DiskCardGame;
using System.Collections;
using System.Collections.Generic;
using TalkingCardAPI.TalkingCards.Create;
using UnityEngine;

namespace TalkingCardAPI.TalkingCards;

public abstract class PartOneTalkingCard : PaperTalkingCard, ITalkingCard
{
    public override DialogueEvent.Speaker SpeakerType => DialogueEvent.Speaker.Stoat;
    public abstract string CardName { get; }
    public abstract List<EmotionData> Emotions { get; }
    public abstract FaceInfo FaceInfo { get; }
    public abstract SpecialTriggeredAbility DialogueAbility { get; }
    public override string OnDrawnFallbackDialogueId => OnDrawnDialogueId;
    public override IEnumerator OnShownForCardSelect(bool forPositiveEffect)
    {
        yield return new WaitForEndOfFrame();
        yield return base.OnShownForCardSelect(forPositiveEffect);
        yield break;
    }
}
