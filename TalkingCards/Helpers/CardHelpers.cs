using DiskCardGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingCardAPI.TalkingCards.Helpers;

internal class CardHelpers
{
    public static CardInfo? Get(string name)
    {
        CardInfo? card;
        try
        {
            card = CardLoader.GetCardByName(name);
        }
        catch (Exception)
        {
            Plugin.LogError($"Couldn't find a card of name {name}!");
            return null;
        }
        return card;
    }
}
