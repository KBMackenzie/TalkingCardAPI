using System;
using System.Linq;

namespace TalkingCardAPI.TalkingCards.Helpers;
public static class StringExtensions
{
    public static string SentenceCase(this string key)
    {
        if (string.IsNullOrWhiteSpace(key)) return string.Empty;
        if (key.Length <= 1) return key.ToUpper();

        return char.ToUpper(key[0]) + key.Substring(1).ToLower();
    }
}
