using DiskCardGame;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalkingCardAPI.TalkingCards.Animation;

internal class DialogueDummy : PaperTalkingCard
{
    public static List<string> AllDialogueAdded = new();

    public const string Dummy = "___dummy";
    public static void DummyEvent()
    {
        DialogueEventGenerator.GenerateEvent(
            Dummy,
            new() { "..." },
            new() { new() { "..." } }
        );
    }

    public string GetEventForCard(string eventName)
    {
        string id = $"{Card.Info.name}_{eventName}";
        return AllDialogueAdded.Contains(id) ? id : Dummy;
    }

    public override string OnDrawnDialogueId
        => GetEventForCard("OnDrawnDialogueId");

    public override string OnPlayFromHandDialogueId
        => GetEventForCard("OnPlayFromHandDialogueId");

    public override string OnAttackedDialogueId
        => GetEventForCard("OnAttackedDialogueId");

    public override string OnBecomeSelectablePositiveDialogueId
        => GetEventForCard("OnBecomeSelectablePositiveDialogueId");

    public override string OnBecomeSelectableNegativeDialogueId
        => GetEventForCard("OnBecomeSelectableNegativeDialogueId");

    public override string OnSacrificedDialogueId
        => GetEventForCard("OnSacrificedDialogueId");

    public override string OnSelectedForDeckTrialDialogueId
        => GetEventForCard("OnSelectedForDeckTrialDialogueId");

    public override string OnSelectedForCardMergeDialogueId
        => GetEventForCard("OnSelectedForCardMergeDialogueId");

    public override string OnSelectedForCardRemoveDialogueId
        => GetEventForCard("OnSelectedForCardRemoveDialogueId");

    public override string OnDiscoveredInExplorationDialogueId
        => GetEventForCard("OnDiscoveredInExplorationDialogueId");

    public override string OnDrawnFallbackDialogueId
    {
        /* This is a fallback. Thus, I'm making it not required.
        * However, users will still have the choice of using it if they want to. */
        get
        {
            string x = GetEventForCard("OnDrawnFallbackDialogueId");
            return x == Dummy ? GetEventForCard("OnDrawnDialogueId") : x;
        }
    }

    public override Dictionary<Opponent.Type, string> OnDrawnSpecialOpponentDialogueIds => new()
    {
        { Opponent.Type.ProspectorBoss,     GetEventForCard("ProspectorBoss")       },
        { Opponent.Type.AnglerBoss,         GetEventForCard("AnglerBoss")           },
        { Opponent.Type.TrapperTraderBoss,  GetEventForCard("TrapperTraderBoss")    },
        { Opponent.Type.LeshyBoss,          GetEventForCard("LeshyBoss")            },
        { Opponent.Type.RoyalBoss,          GetEventForCard("RoyalBoss")            },
        { Opponent.Type.Default,            GetEventForCard("DefaultOpponent")      },
    };

    public override DialogueEvent.Speaker SpeakerType => DialogueEvent.Speaker.Stoat;

    public override IEnumerator OnShownForCardSelect(bool forPositiveEffect)
    {
        yield return new WaitForEndOfFrame();
        yield return base.OnShownForCardSelect(forPositiveEffect);
        yield break;
    }
}
