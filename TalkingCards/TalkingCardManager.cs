using DiskCardGame;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TalkingCardAPI.TalkingCards.Animation;
using TalkingCardAPI.TalkingCards.Create;

namespace TalkingCardAPI.TalkingCards;

public static class TalkingCardManager
{
    // Add a talking card created through this API.
    // I'm using an interface so that it can all be kept in the same class. c:
    public static void New<T>() where T : ITalkingCard, new()
    {
        ITalkingCard x = new T();

        FaceData faceData = new(
                x.CardName,
                x.Emotions,
                x.FaceInfo
            );

        TalkingCardCreator.New(faceData, x.DialogueAbility);
    }

    ///// <summary>
    ///// Register a talking card.
    ///// </summary>
    ///// <param name="faceData">Your talking card's face.</param>
    ///// <param name="script">The <c>SpecialTriggeredAbility</c> that holds your talking card's dialogue.</param>
    //public static void New(FaceData faceData, SpecialTriggeredAbility script)
    //{
    //    Plugin.LogInfo($"Registering talking card {faceData.CardName}!");
    //    TalkingCardCreator.New(faceData, script);
    //}
}