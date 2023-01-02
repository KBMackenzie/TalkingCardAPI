using System;
using System.Linq;

namespace TalkingCardAPI.TalkingCards.Helpers;
public static class EnumHelpers
{
    public static string[] NameArray<T>(bool toLower = false) where T : Enum
    {
        string[] names = Enum.GetNames(typeof(T));
        return toLower ? names.Select(x => x.ToLower()).ToArray() : names;
    }

    public static string FormatKey(this string key)
    {
        if (string.IsNullOrWhiteSpace(key)) return string.Empty;
        if (key.Length <= 1) return key.ToUpper();

        return char.ToUpper(key[0]) + key.Substring(1).ToLower();
    }
}
